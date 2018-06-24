using BettingSystem.Models;
using NUnit.Framework;
using System;
using System.Xml.Linq;
using BettingSystem.Imports;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.ImportsTests
{
    [TestFixture]
    public class XmlConverterTests1
    {
        [Test]
        public void TestParseUpcomingEventSet_CorrectCount()
        {
            SportEvent[] items = XmlConverter.FromXml(File.ReadAllText(@"Xmls/UpcomingEvents.xml")).ToArray();
            Assert.AreEqual(2, items.Length);
        }

        [Test]
        public void TestParseUpdateEventSet_CorrectCount()
        {
            SportEvent[] items = XmlConverter.FromXml(File.ReadAllText(@"Xmls/UpdateEvents.xml")).ToArray();
            Assert.AreEqual(1, items.Length);
        }

        [Test]
        [TestCaseSource(nameof(ParseSportEventImportTestCases))]
        public void TestParseSportEventImport((string Xml, SportEvent Expected) testCase)
        {
            var xmlElement = XElement.Parse(testCase.Xml);
            SportEvent actualElement = XmlConverter.ParseSportEventImport(xmlElement);

            Assert.IsTrue(Comparisons.CompareEvents(testCase.Expected, actualElement));
        }

        public static (string Xml, SportEvent Expected)[] ParseSportEventImportTestCases => new[] {
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
            (
                File.ReadAllText(@"Xmls/FootbalEvent2.xml"),
                new SportEvent {
                    Id = 5097152,
                    SportType="Football",
                    EventTime = DateTime.Parse(@"2018-11-13T19:00:00"),
                    HomePlayer = "Bulgaria",
                    AwayPlayer = "Germany",
                    Markets = new[] {
                        new SportEventMarket {
                            Id=25179248,
                            Number=3,
                            Name="Total Goals",
                            IsClosed=true,
                            Selections=new SportEventSelection[]{}
                        }
                    }
                }
            )
        };
    }
}
