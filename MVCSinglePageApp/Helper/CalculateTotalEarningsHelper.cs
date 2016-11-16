using System;
using System.Collections.Generic;
using System.Linq;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.Entity;
using MVCSinglePageApp.Models;

namespace MVCSinglePageApp.Helper
{
    /// <summary>
    /// Helpers to calculate earnings of a company and sort companies list before sending it to view
    /// </summary>
    public static class CalculateTotalEarningsHelper
    {
        // calculate total earnings of a particular company
        public static void CalculateEarnings(this List<CompanyModel> companies)
        {
            foreach (var company in MvcApplication.Companies)
            {
                if (company.Type == CompanyTypes.Main)
                {
                    company.TotalEarnings = company.Earnings + MvcApplication.Companies.CompanyTotalEarnings(company.Id);
                }
                else
                {
                    company.TotalEarnings = company.Earnings;
                }
            }
        }

        // adding earnings of child companies and subsidiaries
        // recursive function
        private static double CompanyTotalEarnings(this List<CompanyModel> companies, Guid companyId)
        {
            var childsEarnings = 0.0;

            foreach (var company in companies)
            {
                if (company.ParentCompanyId.Equals(companyId))
                {
                    childsEarnings += company.Earnings;
                }
            }

            var childMainCompany = companies.Find(x => x.ParentCompanyId.Equals(companyId) && x.Type == CompanyTypes.Main);

            if (childMainCompany != null)
            {
                childsEarnings += companies.CompanyTotalEarnings(childMainCompany.Id);
            }
            return childsEarnings;
        }
    }
}