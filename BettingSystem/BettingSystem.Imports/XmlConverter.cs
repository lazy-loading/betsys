using System;
using System.Collections.Generic;
using System.Xml.Linq;
using BettingSystem.Models;

namespace BettingSystem.Imports
{
    public static class XmlConverter
    {
        public static IEnumerable<SportEvent> FromXml(string xml)
        {
            try
            {
                return ParseXml(xml);
            }
            catch (Exception e)
            {
                throw new XmlParseException();
            }
        }

        private static IEnumerable<SportEvent> ParseXml(string xml)
        {
            XDocument xDocument = XDocument.Parse(xml);
            foreach (var sportEventImport in xDocument.Root.Elements())
            {
                string sportType = sportEventImport.NodeType.ToString();
                int id = int.Parse(sportEventImport.Attribute("ID").Value);
                DateTime eventTime = DateTime.Parse(sportEventImport.Attribute("EventTime").Value);
                string homePlayer = sportEventImport.Attribute("Home").Value;
                string awayPlayer = sportEventImport.Attribute("Away").Value;

                var sportEvent = new SportEvent
                {
                    Id = id,
                    SportType = sportType.Substring(0, sportType.Length - "event".Length),
                    EventTime = eventTime,
                    HomePlayer = homePlayer,
                    AwayPlayer = awayPlayer
                };

                yield return sportEvent;
            }
        }
    }
}