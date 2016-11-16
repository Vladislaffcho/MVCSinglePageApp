using System;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.BLL.Interfaces
{
    /// <summary>
    /// BL to work with companies
    /// </summary>
    public interface ICompanyBl : ICrudBl<Company>
    {
        // get company type foe=r a new company
        CompanyType GetCompanyType(CompanyTypes companyType);
        //delete company by Id
        void DeleteCompanyById(Guid companyId);
        // gets parent company reference from Db
        Company GetParentCompany(Guid? parentCompanyId);
    }
}