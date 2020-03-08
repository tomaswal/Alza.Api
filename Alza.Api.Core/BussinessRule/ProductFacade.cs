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
        public ICollection<Product> GetAll()
        {
            return productRepository.FindAll().ToList();
        }

        public Product GetById(int id)
        {
            return null;
        }

        public bool Update()
        {
            return true;
        }
    }
}
