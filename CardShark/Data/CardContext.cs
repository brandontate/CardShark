using System.Data.Entity;
using CardShark.Model;

namespace CardShark.Data
{
        //public class UnivercityContext : DbContext
        //{
        //    public DbSet<Professor> Professors { get; set; }
        //    public DbSet<Course> Courses { get; set; }

        //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Configurations.Add(new ProfessorConfiguration());
        //        modelBuilder.Configurations.Add(new CourseConfiguration());
        //    }
        //}

        public class CardContext : DbContext
        {
            public DbSet<Organization> Organizations { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<Match> Matches { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new CardShark.Model.ModelConfigurations.OrganizationConfiguration());
                modelBuilder.Configurations.Add(new CardShark.Model.ModelConfigurations.EventConfiguration());
                modelBuilder.Configurations.Add(new CardShark.Model.ModelConfigurations.MatchConfiguration());
            }
        }
}
