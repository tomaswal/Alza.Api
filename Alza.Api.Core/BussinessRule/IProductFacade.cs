using System.Collections.Generic;
using System.Threading.Tasks;
using Alza.Api.Core.DomainModel;

namespace Alza.Api.Core.BussinessRule
{
    public interface IProductFacade
    {
        Task<List<Product>> GetProductsCollection();
        Product GetProductById(int id);
        Task<bool> UpdateProductDescription(int productId, string description);
    }
}