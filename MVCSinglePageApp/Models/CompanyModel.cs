using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MVCSinglePageApp.DAL.Helpers;

namespace MVCSinglePageApp.Models
{
    /// <summary>
    /// Model represents company entity for views
    /// </summary>
    public class CompanyModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Estimated Earnings")]
        public double Earnings { get; set; }
        [Required]
        [Display(Name = "Total Earnings")]
        public double TotalEarnings { get; set; }
        [Required]
        [Display(Name = "Company Type")]
        public CompanyTypes Type { get; set; }
        [Display(Name = "Parent Company")]
        public Guid? ParentCompanyId { get; set; }
        [Display(Name = "Has Child Company")]
        public bool HasChildCompany { get; set; }
    }
}