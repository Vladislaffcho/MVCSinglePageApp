using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSinglePageApp.Helper;
using MVCSinglePageApp.Models;

namespace MVCSinglePageApp.Controllers
{
    public class CompaniesController : Controller
    {
        // Getting entities from DB and passing them to the view
        public ActionResult Index()
        {
            MvcApplication.Companies = MvcApplication.Companies.SortCompaniesList();
            MvcApplication.Companies.CalculateEarnings();

            ViewBag.Companies = MvcApplication.Companies;
            return View();
        }

        // Creating an entity
        [HttpPost]
        public ActionResult Create(CompanyModel company)
        {
            // server-side validation
            if (company.IsValidToAdd())
            {
                var companyToAdd = company.ToCompany(CompanyAction.Add);
                company.Id = companyToAdd.Id;
                MvcApplication.CompanyBusinessLogic.Add(companyToAdd);
                MvcApplication.Companies.Add(company);
            }

            return RedirectToAction("Index");
        }

        // Updating an entity
        [HttpPost]
        public ActionResult Edit(CompanyModel company)
        {
            // server-side validations
            if (company.IsValidToUpdate())
            {
                    MvcApplication.Companies.Remove(MvcApplication.Companies.Find(x => x.Id == company.Id));
                    MvcApplication.Companies.Add(company);
                    MvcApplication.CompanyBusinessLogic.Update(company.ToCompany(CompanyAction.Update));
            }

            return RedirectToAction("Index");
        }

        // deleting an entity from the db
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            MvcApplication.Companies.Remove(MvcApplication.Companies.Find(x => x.Id.Equals(id)));
            MvcApplication.CompanyBusinessLogic.DeleteCompanyById(id);
            return RedirectToAction("Index");
        }
    }
}
