using System.Collections.Generic;
using Alza.Api.Core.DomainModel;

namespace Alza.Api.Core.BussinessRule
{
    public interface IProductFacade
    {
        ICollection<Product> GetAll();
        Product GetById(int id);
        bool Update();
    }
}