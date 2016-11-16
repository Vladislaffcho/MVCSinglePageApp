using System;
using System.ComponentModel.DataAnnotations;

namespace MVCSinglePageApp.Entity
{
    /// <summary>
    /// DB identifier.
    /// Base class for all DB entities
    /// </summary>
    public class IdentityEntity
    {
        // creating ID before inserting entity to the DB
        public IdentityEntity()
        {
            Id = Guid.NewGuid();
        }

        // primary ey for all tables
        [Key]
        public Guid Id { get; set; }
    }
}
