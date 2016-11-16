using System;
using System.Data.Entity.Migrations;
using System.Linq;
using MVCSinglePageApp.DAL.Repositories.Interfaces;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.DAL.Repositories.Implementations
{
    /// <summary>
    /// Base repository to perform CRUD operations over DB entities
    /// </summary>
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : IdentityEntity
    {
        // declare protected context to be accessible in the derived repositories
        protected CompaniesDbContext ContextDb { get; } = new CompaniesDbContext();

        // addan entity to the DB
        public virtual void Add(TEntity entity)
        {
            ContextDb.Set<TEntity>().Add(entity);
            SaveChanges();
        }
        
        // get a entity from the DB by Id
        public virtual TEntity GetById(Guid id)
        {
            return ContextDb.Set<TEntity>().Find(id);
        }

        // get all entities from the DB
        public virtual IQueryable<TEntity> GetAllEntities()
        {
            return ContextDb.Set<TEntity>();
        }

        // delete an entity itself
        public virtual void Delete(TEntity entity)
        {
            ContextDb.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        // update an entity
        public virtual void Update(TEntity entity)
        {
            ContextDb.Set<TEntity>().AddOrUpdate<TEntity>(entity);
            SaveChanges();
        }

        // save changes after performing an operation
        public virtual void SaveChanges()
        {
            ContextDb.SaveChanges();
        }
    }
}