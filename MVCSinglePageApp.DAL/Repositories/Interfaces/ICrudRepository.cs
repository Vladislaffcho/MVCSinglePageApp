using System;
using System.Linq;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Base interface to be implemented by CrudRepository class
    /// </summary>
    public interface ICrudRepository<TEntity> where TEntity : IdentityEntity
    {
        // add an entity to DB
        void Add(TEntity entity);
        // get an entity from DB using ID
        TEntity GetById(Guid id);
        // get all entities from DB
        IQueryable<TEntity> GetAllEntities();
        // delete particular entity
        void Delete(TEntity entity);
        // update an entity in DB
        void Update(TEntity entity);
        // save changes once operation has been completed
        void SaveChanges();
    }
}