using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.DAL
{
    /// <summary>
    /// DB context for creating the DB and CRUD operations
    /// </summary>
    public class CompaniesDbContext : DbContext
    {
        public CompaniesDbContext() : base("dbConnection")
        {
            //setting DB intializer
            Database.SetInitializer(new CompaniesDbInitializer());
            Database.Initialize(true);
        }

        // Context entities
        public DbSet<Company> Companies { get; set; } //1
        public DbSet<CompanyType> CompanyTypes { get; set; } //2

    }
}
