using System;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.DAL.Repositories.Interfaces
{
    /// <summary>
    /// To be implemented by CompanyRepository
    /// </summary>
    public interface ICompanyRepository : ICrudRepository<Company>
    {
        // get company type from the DB
        CompanyType GetCompanyType(CompanyTypes companyType);
        // add parent company
        Company GetParentCompany(Guid? paretnCompanyId);
        // deletes a company with its children from Db
        void DeleteCompany(Guid companyId);
    }
}