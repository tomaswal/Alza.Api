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
        private readonly IUnitOfWork unitOfWork;
        public ProductFacade(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICollection<Product> GetProductsCollection()
        {
            return productRepository.FindAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return productRepository.FindById(id);
        }

        public bool UpdateProduct(Product product)
        {
            var dbProduct = productRepository.FindById(product.Id);

            dbProduct.Description = product.Description;
            dbProduct.ImgUri = product.ImgUri;
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;

            unitOfWork.SaveChanges();

            return true;
        }
    }
}
