using System.ComponentModel.DataAnnotations;

namespace MVCSinglePageApp.Entity
{
    /// <summary>
    /// Base class for entities with names
    /// </summary>
    public class NamedEntity : IdentityEntity
    {
        // company or company type name
        [MinLength(1, ErrorMessage = "Too short name. Must be 1-100 chars")]
        [MaxLength(100, ErrorMessage = "Too long name. Must be 1-100 chars")]
        [Required]
        public string Name { get; set; }
    }
}