using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardShark.Model;
using System.Data.Entity;

namespace CardShark.Model
{
    public class DummyData : DropCreateDatabaseAlways<CardContext>
    {
        protected override void Seed(CardContext context)
        {
            context.Organizations.Add(new Organization
            {
                id = 1,
                Name = "WWE",
                Events = new List<Event>
                {
                    new Event
                    {
                        id = 1,
                        eventName = "Royal Rumble",
                        eventDate = new DateTime(2015, 01, 25, 19, 0, 0),
                        Matches = new List<Match> 
                        {
                            new Match
                            {
                                FirstOppenent = "The Bella Twins",
                                SecondOppenent = "Paige",
                                Winner = "The Bella Twins"
                            }
                        }
                    },

                    new Event
                    {
                        id = 2,
                        eventName = "Fastlane",
                        eventDate = new DateTime(2015, 02, 17, 19, 0, 0),
                        Matches = new List<Match>
                        {
                            new Match
                            {
                                FirstOppenent = "Daniel Bryan",
                                SecondOppenent = "Roman Reigns",
                                Winner = "Daniel Bryan"
                            }

                        }
                    },

                    new Event
                    {
                        id = 3,
                        eventName = "TLC",
                        eventDate = new DateTime(2014, 12, 14, 19, 0, 0),
                        Matches = new List<Match>
                        {
                            new Match
                            {
                                FirstOppenent = "The New Day",
                                SecondOppenent = "Goldust & Stardust",
                                Winner = "The New Day"
                            },
                            new Match
                            {
                                FirstOppenent = "Dolph Ziggler",
                                SecondOppenent = "Luke Harper",
                                Winner = "Dolph Ziggler"
                            },
                            new Match
                            {
                                FirstOppenent = "The Usos",
                                SecondOppenent = "The Miz & Damien Mizdow",
                                Winner = "The Usos"
                            },
                            new Match
                            {
                                FirstOppenent = "Big Show",
                                SecondOppenent = "Erick Rowan",
                                Winner = "Big Show"
                            },
                            new Match
                            {
                                FirstOppenent = "John Cena",
                                SecondOppenent = "Seth Rollins",
                                Winner = "John Cena"
                            },
                            new Match
                            {
                                FirstOppenent = "Nikki Bella",
                                SecondOppenent = "AJ Lee",
                                Winner = "Nikki Bella"
                            },
                            new Match
                            {
                                FirstOppenent = "Ryback",
                                SecondOppenent = "Kane",
                                Winner = "Ryback"
                            },
                            new Match
                            {
                                FirstOppenent = "Rusev",
                                SecondOppenent = "Jack Swagger",
                                Winner = "Rusev"
                            },
                            new Match
                            {
                                FirstOppenent = "Bray Wyatt",
                                SecondOppenent = "Dean Ambrose",
                                Winner = "Bray Wyatt"
                            }
                        }
                    }
                }
            });
            context.Organizations.Add(new Organization
            {
                id = 2,
                Name = "UFC",
                Events = new List<Event>
                {
                    new Event
                    {
                        id = 1,
                        eventName = "UFC 183",
                        eventDate = new DateTime(2015,01,31,19,0,0),
                        Matches = new List<Match>
                        {
                            new Match { FirstOppenent = "Anderson 'The Spider' Silva", SecondOppenent = "Nick Diaz", Winner = "Anderson 'The Spider' Silva"}
                        }
                    },

                    new Event
                    {
                        id = 2,
                        eventName = "UFC 184",
                        eventDate = new DateTime(2015,02,28,19,0,0),
                        Matches = new List<Match>
                        {
                            new Match { FirstOppenent = "Masio Fullen", SecondOppenent = "Alexander Torres" },
                            new Match { FirstOppenent = "James Krause", SecondOppenent = "Valmir Lazaro" },
                            new Match { FirstOppenent = "Derrick Lewis", SecondOppenent = "Ruan Potts" },
                            new Match { FirstOppenent = "Dhiego Lima", SecondOppenent = "Tim Means" },
                            new Match { FirstOppenent = "Roman Salazar", SecondOppenent = "Norifumi Yamamoto" },
                            new Match { FirstOppenent = "Mark Muñoz", SecondOppenent = "Roan Carneiro" },
                            new Match { FirstOppenent = "Tony Ferguson", SecondOppenent = "Gleison Tibau" },
                            new Match { FirstOppenent = "Alan Jouban", SecondOppenent = "Richard Walsh" },
                            new Match { FirstOppenent = "Jake Ellenberger", SecondOppenent = "Josh Koscheck" },
                            new Match { FirstOppenent = "Raquel Pennington", SecondOppenent = "Holly Holm" },
                            new Match { FirstOppenent = "Rhonda Rousey", SecondOppenent = "Catt Zigano" }   
                        }
                    }
                    
                }

            });
        }
    }
}
