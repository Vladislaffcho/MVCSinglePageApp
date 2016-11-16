using System;
using System.Linq;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.DAL.Repositories.Interfaces;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations over Company entity
    /// </summary>
    public class CompanyRepository : CrudRepository<Company>, ICompanyRepository
    {
        // get company type from the DB
        public CompanyType GetCompanyType(CompanyTypes companyType)
        {
            return ContextDb.CompanyTypes.FirstOrDefault(x => x.Name == companyType.ToString());
        }

        // get parent company from Db
        public Company GetParentCompany(Guid? paretnCompanyId)
        {
            return ContextDb.Companies.FirstOrDefault(x => x.Id == paretnCompanyId);
        }

        // deletes company and all children from Db
        public void DeleteCompany(Guid companyId)
        {
            Delete(GetById(companyId));
        }
    }
}