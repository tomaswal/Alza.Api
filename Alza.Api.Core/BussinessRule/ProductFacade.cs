using Alza.Api.Core.DomainModel;
using Alza.Api.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Api.Core.BussinessRule
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductFacade(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> GetProductsCollection()
        {
            return await productRepository.FindAllAsync();
        }

        public Product GetProductById(int id)
        {
            return productRepository.FindById(id);
        }

        public async Task<bool> UpdateProductDescription(int productId, string description)
        {
            if (string.IsNullOrEmpty(description))
                description = string.Empty;

            var dbProduct = productRepository.FindById(productId);

            dbProduct.Description = description;

            await unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
