using PeopleSearch.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PeopleSearch.DAL
{
    public class PeopleSearchContext : DbContext
    {

        public PeopleSearchContext()
            : base("PeopleSearchContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        //Creating the DAL

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        //disabling the plural naming convention
    }
}