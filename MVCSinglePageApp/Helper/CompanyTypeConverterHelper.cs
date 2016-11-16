using System;
using MVCSinglePageApp.BLL.Implementations;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.Entity;
using MVCSinglePageApp.Models;

namespace MVCSinglePageApp.Helper
{
    /// <summary>
    /// Helper to convert Company to CompanyModel and back
    /// </summary>
    public static class CompanyTypeConverterHelper
    {
        // method converts Company into CompanyModel
        public static CompanyModel ToCompanyModel(this Company company)
        {
            var convertedCompany = new CompanyModel()
            {
                Id = company.Id,
                Name = company.Name,
                Earnings = company.AnnualEarnings,
                Type = (CompanyTypes)Enum.Parse(typeof(CompanyTypes), company.CompanyType.Name)
            };

            if (company.ParentCompany != null)
            {
                convertedCompany.ParentCompanyId = company.ParentCompany.Id;
            }
            return convertedCompany;
        }

        // method converts Company into CompanyModel
        public static Company ToCompany(this CompanyModel company)
        {
            var convertedCompany = new Company()
            {
                Name = company.Name,
                AnnualEarnings = company.Earnings,
                CompanyType = MvcApplication.CompanyBusinessLogic.GetCompanyType(company.Type)
            };

            if (company.Id != Guid.Empty)
            {
                convertedCompany.Id = company.Id;
            }

            if (company.ParentCompanyId != null)
            {
                convertedCompany.ParentCompany =
                    MvcApplication.CompanyBusinessLogic.GetParentCompany(company.ParentCompanyId);
            }
            return convertedCompany;
        }
    }
}