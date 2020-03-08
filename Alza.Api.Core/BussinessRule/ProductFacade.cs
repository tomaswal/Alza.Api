using Alza.Api.Core.DomainModel;
using Alza.Api.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alza.Api.Core.BussinessRule
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository productRepository;
        public ProductFacade(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public ICollection<Product> GetProductsCollection()
        {
            return productRepository.FindAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return productRepository.FindById(id);
        }

        public bool Update(Product product)
        {
            return true;
        }
    }
}
