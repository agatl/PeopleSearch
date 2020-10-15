using Sample.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sample.Repository
{

    // This module will be responsible for database and tables generation. I am not creating any DB and tables for this demo.
    public class PeopleContext:DbContext
    {
        // Will create People and People Interests table
        public DbSet<People> Peoples { get; set; }
        
        // Will create People Image table.
        // For better performance store Image in different table.
        public DbSet<PeopleImage> PeopleImages { get; set; }

        public PeopleContext()
            : base("PeopleContext")
        {
            Database.SetInitializer<PeopleContext>(new CreateDatabaseIfNotExists<PeopleContext>());


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
