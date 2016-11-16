using System.ComponentModel.DataAnnotations;

namespace MVCSinglePageApp.Entity
{
    /// <summary>
    /// Base class for both main companies and subsidiaries
    /// </summary>
    public class Company : NamedEntity
    {
        // annual earnings
        [Required]
        public double AnnualEarnings { get; set; }

        // parent company
        public virtual Company ParentCompany { get; set; }

        // company type
        [Required]
        public virtual CompanyType CompanyType { get; set; }
    }
}