using System.Collections.Generic;
using Alza.Api.Core.DomainModel;

namespace Alza.Api.Core.BussinessRule
{
    public interface IProductFacade
    {
        ICollection<Product> GetProductsCollection();
        Product GetProductById(int id);
        bool UpdateProduct(Product product);
    }
}