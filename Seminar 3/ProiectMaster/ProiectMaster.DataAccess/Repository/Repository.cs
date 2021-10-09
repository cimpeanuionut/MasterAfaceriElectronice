using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProiectMaster.DataAccess.Repository
{
    public class Repository<T, G> : IRepository<T, G> where T : class, IEntity<G> where G : IEquatable<G>
    {
        protected readonly MagazinVirtualContext _db;

        public Repository(MagazinVirtualContext db)
        {
            _db = db;
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().AsEnumerable();
        }

        public T GetInstance(G id)
        {
            return _db.Set<T>().SingleOrDefault(t => t.Id.Equals(id));
        }

        public bool IsUnique(Expression<Func<T, bool>> predicate)
        {
            return !_db.Set<T>().Any(predicate);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
    }
}
