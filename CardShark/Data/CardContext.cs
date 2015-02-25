using System.Data.Entity;
using CardShark.Model;

namespace CardShark.Data
{
        public class CardContext : DbContext
        {
            public DbSet<Organization> Organizations { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<Match> Matches { get; set; }
            public DbSet<Guess> Guesses { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new ModelConfigurations.OrganizationConfiguration());
                modelBuilder.Configurations.Add(new ModelConfigurations.EventConfiguration());
                modelBuilder.Configurations.Add(new ModelConfigurations.MatchConfiguration());
                modelBuilder.Configurations.Add(new ModelConfigurations.GuessConfiguration());
            }
        }
}
