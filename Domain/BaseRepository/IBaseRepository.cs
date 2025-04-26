using Domain.UnitOfWork;
using Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseRepository
{
    public interface IBaseRepository<T , K> where T : IBaseEntity<K> where K : IEquatable<K>
    {
        Task<T> FindAsync(K id);
        IQueryable<T> Get(Expression<Func<T, bool>>? predicate);

        IUnitOfWork unitOfWork { get; }
        
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        void AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        void DeleteRange(List<T> entities);

    }
}
