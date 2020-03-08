using Alza.Api.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Api.Core.Repository
{
    public interface IRepository<T, K> where T : IEntity<K>
                                       where K : struct
    {
        ICollection<T> FindAll();
        T FindById(K id);
        void Add(T entity);
        void Remove(T entity);

        Task<List<T>> FindAllAsync();
        Task<T> FindByIdAsync(K id);
        Task AddAsync(T entity);
    }
}
