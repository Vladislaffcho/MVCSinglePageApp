using System;
using MVCSinglePageApp.BLL.Interfaces;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.DAL.Repositories.Interfaces;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.BLL.Implementations
{
    public class CompanyBl : CrudBl<ICompanyRepository, Company>, ICompanyBl
    {
        public CompanyBl(ICompanyRepository repository) : base(repository)
        {
            
        }

        // get company type of a company which will be added to the DB
        public CompanyType GetCompanyType(CompanyTypes companyType)
        {
            return Repository.GetCompanyType(companyType);
        }

        // deleting company from Db by Id
        public void DeleteCompanyById(Guid companyId)
        {
            Repository.DeleteCompany(companyId);
        }

        // gets parent company reference
        public Company GetParentCompany(Guid? parentCompanyId)
        {
            return Repository.GetParentCompany(parentCompanyId);
        }
    }
}
