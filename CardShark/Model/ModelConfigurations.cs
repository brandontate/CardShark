using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace CardShark.Model
{
    public class ModelConfigurations
    {

        public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
        {
            public OrganizationConfiguration()
            {
                Property(o => o.id);
                Property(o => o.Name).IsRequired().HasMaxLength(10);
            }
        }

        public class EventConfiguration : EntityTypeConfiguration<Event>
        {
            public EventConfiguration()
            {
                Property(e => e.id);
                Property(e => e.eventName).IsRequired().HasMaxLength(50);
                Property(e => e.eventDate).IsRequired();
            }
        }

        public class MatchConfiguration : EntityTypeConfiguration<Match>
        {
            public MatchConfiguration()
            {
                Property(m => m.FirstOppenent).IsRequired();
                Property(m => m.SecondOppenent).IsRequired();
                Property(m => m.Winner);

            }
        }

        public class GuessConfiguration : EntityTypeConfiguration<Guess>
        {
            public GuessConfiguration()
            {
                Property(g => g.id);
                Property(g => g.guess);
            }
        }
    }
}
