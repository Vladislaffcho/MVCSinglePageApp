using System.Collections.Generic;
using System.Linq;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.Models;

namespace MVCSinglePageApp.Helper
{
    /// <summary>
    /// Helper to sort list of companies before sending it to view
    /// </summary>
    public static class CompaniesSortHelper
    {
        // sort companies list before sending it to view
        public static List<CompanyModel> SortCompaniesList(this List<CompanyModel> companies)
        {
            var companiesList = new List<CompanyModel>();

            // building a tree of companies which do not have parent companies
            foreach (var company in companies)
            {
                if (company.ParentCompanyId == null)
                {
                    companiesList.Add(company);
                    companiesList.AddRange(companies.AddCompanies(company));
                }
            }

            return companiesList;
        }

        // Function to add companies to a new list
        // recursive function
        private static List<CompanyModel> AddCompanies(this List<CompanyModel> companies, CompanyModel company)
        {
            var companiesList = new List<CompanyModel>();

            // check if a company has subsidiaries
            var subsidiaries = companies.Where(x => x.ParentCompanyId == company.Id && x.Type == CompanyTypes.Subsidiary).ToList();

            if (subsidiaries.Count > 0)
            {
                company.HasChildCompany = true;
            }

            companiesList.AddRange(subsidiaries);

            // check if a company has another Main company as a child
            var subsidiaryCompany =
                companies.FirstOrDefault(x => x.ParentCompanyId == company.Id && x.Type == CompanyTypes.Main);

            if (subsidiaryCompany != null)
            {
                company.HasChildCompany = true;
                companiesList.Add(subsidiaryCompany);
                companiesList.AddRange(companies.AddCompanies(subsidiaryCompany));
            }

            return companiesList;
        }
    }
}