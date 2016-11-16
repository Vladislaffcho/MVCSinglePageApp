using System;
using System.Linq;
using MVCSinglePageApp.BLL.Interfaces;
using MVCSinglePageApp.DAL.Repositories.Interfaces;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.BLL.Implementations
{
    /// <summary>
    /// Base business logic class
    /// to be base one for all other business logic classes
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class CrudBl<TRepository, TEntity> : ICrudBl<TEntity>
        where TEntity : IdentityEntity
        where TRepository : class, ICrudRepository<TEntity>
    {
        // repository for working with particular business logic
        protected TRepository Repository { get; private set; }

        // constructor which takes particular repository as a parameter
        protected CrudBl(TRepository repository)
        {
            Repository = repository;
        }

        // add entity method
        public void Add(TEntity entity)
        {
            Repository.Add(entity);
        }

        // get entity by Id method
        public TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        // get al entities method
        public IQueryable<TEntity> GetAllEntities()
        {
            return Repository.GetAllEntities();
        }

        // delete an entity method
        public void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }

        // update an entity
        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }
    }
}