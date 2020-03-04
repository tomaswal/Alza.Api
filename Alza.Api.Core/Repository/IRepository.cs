using Alza.Api.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.Repository
{
    public interface IRepository<T> where T : struct
    {
        ICollection<IEntity<T>> FindAll();
        IEntity<T> FindById(T id);
        void Remove(IEntity<T> entity);
    }
}
