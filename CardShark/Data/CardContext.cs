using System.Data.Entity;

namespace CardShark.Model
{
        public class CardContext : DbContext
        {
            public DbSet<Organization> Organizations { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<Match> Matches { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new ModelConfigurations.OrganizationConfiguration());
                modelBuilder.Configurations.Add(new ModelConfigurations.EventConfiguration());
                modelBuilder.Configurations.Add(new ModelConfigurations.MatchConfiguration());
            }
        }
}
