using BettingSystem.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettingSystem.Models;
using System.Xml.Linq;
using BettingSystem.Imports;
using System.IO;

namespace BettingSystem.ImportsTests
{
    [TestFixture]
    public class XmlConverterTests
    {
        [Test]
        public void Testkur()
        {

        }
        [Test]
        //[TestCaseSource(nameof(ParseSportEventImportTestCases))]
        public void TestParseSportEventImport((string Xml, SportEvent Expected) testCase)
        {
            var xmlElement = XElement.Parse(testCase.Xml);
            SportEvent actualElement = XmlConverter.ParseSportEventImport(xmlElement);

            Assert.IsTrue(CompareEvents(testCase.Expected, actualElement));
        }

        private static bool CompareEvents(SportEvent x, SportEvent y)
        {
            return
                x.HomePlayer == y.HomePlayer &&
                x.AwayPlayer == y.AwayPlayer &&
                x.EventTime == y.EventTime &&
                x.Id == y.Id &&
                x.SportType == y.SportType;
        }

        private static readonly (string Xml, SportEvent Expected)[] ParseSportEventImportTestCases = {
            (
                File.ReadAllText(@"Xmls/FootbalEvent1.xml"),
                new SportEvent {
                    SportType = "Football",
                    HomePlayer = "Bulgaria",
                    AwayPlayer = "Germany",
                    EventTime = DateTime.Parse("2018-11-13T19:00:00"),
                    Id = 5097152
                }
            ),
        };
    }
}
