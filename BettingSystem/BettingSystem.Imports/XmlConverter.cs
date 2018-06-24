using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BettingSystem.Models;

namespace BettingSystem.Imports
{
    public static class XmlConverter
    {
        private static readonly IReadOnlyDictionary<string, SelectionParticipantType> ParticipantTypesByName = new Dictionary<string, SelectionParticipantType> {
            {"AWAY" , SelectionParticipantType.Away},
            {"DRAW", SelectionParticipantType.Draw },
            {"HOME", SelectionParticipantType.Home }
        };

        public static IEnumerable<SportEvent> FromXml(string xml)
        {
            try
            {
                return ParseXmlEnumerable(xml);
            }
            catch (Exception e)
            {
                throw new XmlParseException();
            }
        }

        private static IEnumerable<SportEvent> ParseXmlEnumerable(string xml)
        {
            XDocument xDocument = XDocument.Parse(xml);
            foreach (XElement sportEventImport in xDocument.Root.Elements())
            {
                yield return ParseSportEventImport(sportEventImport);
            }
        }

        public static SportEvent ParseSportEventImport(XElement sportEventImport)
        {
            var sportEvent = new SportEvent {
                Id = int.Parse(sportEventImport.Attribute("ID").Value),
                SportType = TrimSuffix(sportEventImport.Name.ToString(), "Event"),
                EventTime = DateTime.Parse(sportEventImport.Attribute("EventTime").Value),
                HomePlayer = sportEventImport.Attribute("Home").Value,
                AwayPlayer = sportEventImport.Attribute("Away").Value,
                Markets = sportEventImport.Elements().Where(x => x.Name == "Market").Select(ParseMarket).ToArray()
            };

            return sportEvent;
        }

        private static string TrimSuffix(string text, string suffix)
        {
            if (!text.EndsWith(suffix)) throw new ArgumentException("No suffix");
            return text.Substring(0, text.Length - suffix.Length);
        }

        private static SportEventMarket ParseMarket(XElement marketImport)
        {
            if (marketImport == null)
                throw new ArgumentNullException(nameof(marketImport));

            var market = new SportEventMarket {
                Id = int.Parse(marketImport.Attribute("ID").Value),
                Number = int.Parse(marketImport.Attribute("Number").Value),
                Name = marketImport.Attribute("Name").Value,
                Selections = marketImport.Elements().Where(x => x.Name == "Selection").Select(ParseSelection).ToArray(),
                IsClosed = marketImport.Attribute("Status")?.Value == "Close"
            };
            return market;
        }

        private static SportEventSelection ParseSelection(XElement selectionImport)
        {
            var selection = new SportEventSelection {
                Id = int.Parse(selectionImport.Attribute("ID").Value),
                Number = int.Parse(selectionImport.Attribute("Number").Value),
                Odds = decimal.Parse(selectionImport.Attribute("OddsDecimal").Value),
                Participant = GetParticipantTypeByName(selectionImport.Attribute("Participant")?.Value),
                Description = selectionImport.Attribute("Description")?.Value
            };

            return selection;
        }

        private static SelectionParticipantType? GetParticipantTypeByName(string name)
        {
            if (name == null) return null;
            else return XmlConverter.ParticipantTypesByName[name];
        }
    }
}