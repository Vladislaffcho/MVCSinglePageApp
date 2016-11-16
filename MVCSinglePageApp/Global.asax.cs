using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVCSinglePageApp.BLL.Implementations;
using MVCSinglePageApp.DAL.Helpers;
using MVCSinglePageApp.DAL.Repositories.Implementations;
using MVCSinglePageApp.Entity;
using MVCSinglePageApp.Helper;
using MVCSinglePageApp.Models;

namespace MVCSinglePageApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static CompanyBl CompanyBusinessLogic = new CompanyBl(new CompanyRepository());
        public static List<CompanyModel> Companies = new List<CompanyModel>();

        protected void Application_Start()
        {
            var dbCompanies = CompanyBusinessLogic.GetAllEntities().ToList();
            foreach (var company in dbCompanies)
            {
                Companies.Add(company.ToCompanyModel());
            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
