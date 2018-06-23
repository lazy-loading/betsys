using BettingSystem.Models;
using NUnit.Framework;
using System;
using System.Xml.Linq;
using BettingSystem.Imports;
using System.IO;

namespace BettingSystem.ImportsTests
{
    [TestFixture]
    public class XmlConverterTests1
    {
        [Test]
        [TestCaseSource(nameof(ParseSportEventImportTestCases))]
        public void TestParseSportEventImport((string Xml, SportEvent Expected) testCase)
        {
            var xmlElement = XElement.Parse(testCase.Xml);
            SportEvent actualElement = XmlConverter.ParseSportEventImport(xmlElement);

            Assert.IsTrue(Comparisons.CompareEvents(testCase.Expected, actualElement));
        }

        public static (string Xml, SportEvent Expected)[] ParseSportEventImportTestCases { get; } = new[] {
            (
                File.ReadAllText(@"Xmls/FootbalEvent1.xml"),
                new SportEvent {
                    SportType = "Football",
                    HomePlayer = "Bulgaria",
                    AwayPlayer = "Germany",
                    EventTime = DateTime.Parse("2018-11-13T19:00:00"),
                    Id = 5097152,
                    Markets = new[] {
                        new SportEventMarket {
                            Id = 25179210,
                            Number=1,
                            Name = "Match Result",
                            Selections = new[] {
                                new SportEventSelection {
                                    Id=60475643,
                                    Number=1,
                                    Odds=2.55M,
                                    Participant=SelectionParticipantType.Home
                                },
                                new SportEventSelection {
                                    Id = 60475645,
                                    Number=2,
                                    Odds=3.83M,
                                    Participant=SelectionParticipantType.Draw
                                },
                                new SportEventSelection {
                                    Id=60475644,
                                    Number=3,
                                    Odds=2.31M,
                                    Participant=SelectionParticipantType.Away
                                }
                            }
                        },
                        new SportEventMarket {
                            Id=25179221,
                            Number=4,
                            Name="Penalty in Match",
                            Selections = new[] {
                                new SportEventSelection {
                                    Id=60475707,
                                    Number=1,
                                    Description="Yes",
                                    Odds=22.24M
                                },
                                new SportEventSelection {
                                    Id=60475707,
                                    Number=2,
                                    Description="No",
                                    Odds=1.24M
                                }
                            }
                        }
                    }
                }
            ),
        };
    }
}
