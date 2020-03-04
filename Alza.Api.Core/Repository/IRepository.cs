using Alza.Api.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.Repository
{
    public interface IRepository<T, K> where T : IEntity<K>
                                       where K : struct
    {
        ICollection<T> FindAll();
        T FindById(K id);
        void Remove(T entity);
    }
}
