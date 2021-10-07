using MagazinOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MagazinOnline.DataAcces
{
    public interface IRepository<T, G> where T : class, IEntity<G> where G : IEquatable<G>
    {
        IEnumerable<T> GetAll(); 
        T GetInstance(G id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        bool IsUnique(Expression<Func<T, bool>> predicate);        
        Task<IEnumerable<T>> GetAllAsync();       
        Task<T> GetInstanceAsync(G id);     
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity); 
    }
}
