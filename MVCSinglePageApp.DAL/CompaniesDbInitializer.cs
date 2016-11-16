using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.DAL
{
    public class CompaniesDbInitializer : CreateDatabaseIfNotExists<CompaniesDbContext>
    {
        protected override void Seed(CompaniesDbContext context)
        {
            var defaultTypes = new List<CompanyType>()
            {
                new CompanyType()
                {
                    Name = CompanyTypes.Main.ToString()
                },
                new CompanyType()
                {
                    Name = CompanyTypes.Subsidiary.ToString()
                }
            };

            context.CompanyTypes.AddRange(defaultTypes);
            context.SaveChanges();


            var defaultMainCompanies = new List<Company>()
            {
                new Company()
                {
                    Name = "Booble",
                    AnnualEarnings = 700,
                    CompanyType = context.CompanyTypes.FirstOrDefault(x => x.Name == CompanyTypes.Main.ToString())
                },
                new Company()
                {
                    Name = "ABCcompany",
                    AnnualEarnings = 800,
                    CompanyType = context.CompanyTypes.FirstOrDefault(x => x.Name == CompanyTypes.Main.ToString())
                }
            };

            context.Companies.AddRange(defaultMainCompanies);
            context.SaveChanges();


            var defaultSubsidiaryCompanies = new List<Company>()
            {
                new Company()
                {
                    Name = "New York subsidiary",
                    AnnualEarnings = 300,
                    CompanyType = context.CompanyTypes.FirstOrDefault(x => x.Name == CompanyTypes.Subsidiary.ToString()),
                    ParentCompany = context.Companies.FirstOrDefault(x => x.Name == "Booble")
                },
                new Company()
                {
                    Name = "Vinnytsia subsidiary",
                    AnnualEarnings = 300,
                    CompanyType = context.CompanyTypes.FirstOrDefault(x => x.Name == CompanyTypes.Subsidiary.ToString()),
                    ParentCompany = context.Companies.FirstOrDefault(x => x.Name == "Booble")
                },
                new Company()
                {
                    Name = "Kyiv subsidiary",
                    AnnualEarnings = 300,
                    CompanyType = context.CompanyTypes.FirstOrDefault(x => x.Name == CompanyTypes.Subsidiary.ToString()),
                    ParentCompany = context.Companies.FirstOrDefault(x => x.Name == "ABCcompany")
                },
                new Company()
                {
                    Name = "London subsidiary",
                    AnnualEarnings = 300,
                    CompanyType = context.CompanyTypes.FirstOrDefault(x => x.Name == CompanyTypes.Subsidiary.ToString()),
                    ParentCompany = context.Companies.FirstOrDefault(x => x.Name == "ABCcompany")
                }
            };
            context.Companies.AddRange(defaultSubsidiaryCompanies);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}