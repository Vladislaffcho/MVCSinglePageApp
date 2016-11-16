using System;
using System.Linq;
using MVCSinglePageApp.Entity;

namespace MVCSinglePageApp.BLL.Interfaces
{
    /// <summary>
    /// Interface to be implemented by CrudBl class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICrudBl<TEntity> where TEntity : IdentityEntity
    {
        // add an entity
        void Add(TEntity entity);
        // get an entity
        TEntity GetById(Guid id);
        // get all entities
        IQueryable<TEntity> GetAllEntities();
        // delete particular entity
        void Delete(TEntity entity);
        // update an entity in DB
        void Update(TEntity entity);
    }
}