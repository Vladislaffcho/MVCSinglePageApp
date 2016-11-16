using System;
using System.Linq;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.Models;

namespace MVCSinglePageApp.Helper
{
    /// <summary>
    /// Helper to validate user input
    /// </summary>
    public static class ValidateCompanyDataHelper
    {
        // is a company to be added is valid
        public static bool IsValidToAdd(this CompanyModel company)
        {
            if (company.Name.Equals(String.Empty))
            {
                return false;
            }

            if (company.Type == CompanyTypes.Main && company.IsWithParent())
            {
                company.ParentCompanyId = null;
            }
            return true;
        }

        // check if a company has a Main child company
        // a company may have only one main child company
        private static bool IsParentCompanyWithChild(this CompanyModel company)
        {
            if (company.ParentCompanyId != null)
            {
                return MvcApplication.Companies.First(x => x.Id == company.ParentCompanyId).HasChildCompany;
            }
            return false;
        }

        // check if a has a parent company
        private static bool IsWithParent(this CompanyModel company)
        {
            if (company.ParentCompanyId != null)
            {
                return company.IsParentCompanyWithChild();
            }

            return false;
        }

        // if ut is a valid update
        // return false if update is invalid
        public static bool IsValidToUpdate(this CompanyModel company)
        {
            // check ID input
            if (company.Id == Guid.Empty)
            {
                return false;
            }

            var companyToCompare = MvcApplication.Companies.First(x => x.Id == company.Id);

            // check if there is data to update
            if (company.Name.Equals(companyToCompare.Name) &&
                company.Type == companyToCompare.Type &&
                company.ParentCompanyId == companyToCompare.ParentCompanyId &&
                company.Earnings.Equals(companyToCompare.Earnings))
            {
                return false;
            }

            // is valid subsidiary company
            if (company.Type == CompanyTypes.Subsidiary && companyToCompare.HasChildCompany)
            {
                return false;
            }

            // check if a parent company can have a main company as a child
            if (company.Type == CompanyTypes.Main && company.IsWithParent())
            {
                company.ParentCompanyId = Guid.Empty;
            }

            return true;
        }
    }
}