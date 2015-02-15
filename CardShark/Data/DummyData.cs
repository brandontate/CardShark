using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardShark.Model;
using System.Data.Entity;

namespace CardShark.Data
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
                        eventDate = "01/25/2015",
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
                        eventDate = "02/22/2015",
                        Matches = new List<Match>
                        {
                            new Match
                            {
                                FirstOppenent = "Daniel Bryan",
                                SecondOppenent = "Roman Reigns",
                                Winner = "Daniel Bryan"
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
                        eventDate = "01/31/2015",
                        Matches = new List<Match>
                        {
                            new Match
                            {
                                FirstOppenent = "Anderson 'The Spider' Silva",
                                SecondOppenent = "Nick Diaz",
                                Winner = "Anderson 'The Spider' Silva"
                            }
                        }
                    },

                    new Event
                    {
                        id = 2,
                        eventName = "UFC 184",
                        eventDate = "02/28/2015",
                        Matches = new List<Match>
                        {
                            new Match
                            {
                                FirstOppenent = "Rhonda Rousey",
                                SecondOppenent = "Catt Zigano",
                                Winner = "Rhonda Rousey"
                            }
                        }
                    }
                    
                }

            });
        }
    }
}
