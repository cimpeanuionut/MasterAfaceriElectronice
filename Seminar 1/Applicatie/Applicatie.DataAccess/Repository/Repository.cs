using MagazinOnline.DataAcces.Entities;
using MagazinOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MagazinOnline.DataAcces
{
    public class Repository<T, G> : IRepository<T, G> where T : class, IEntity<G> where G : IEquatable<G>
    {
        protected readonly MagazinVirtualContext _db;
        public Repository(MagazinVirtualContext db) 
        {
            _db = db;
        }

        #region Sync

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }      

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public T GetInstance(G id)
        {
            return _db.Set<T>().SingleOrDefault(t => t.Id.Equals(id));
        }
      
        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _db.Set<T>().Where(predicate);
            foreach (var entity in entities)
                _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().AsEnumerable();
        }      

        public bool IsUnique(Expression<Func<T, bool>> predicate)
        {
            return !_db.Set<T>().Any(predicate);
        }     

        #endregion Sync

        #region Async

        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }       

        public async Task<T> GetInstanceAsync(G id)
        {
            return await _db.Set<T>().SingleOrDefaultAsync(t => t.Id.Equals(id));
        }     

        #endregion Async      
    }
}
