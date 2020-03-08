using Alza.Api.Core.DomainModel;
using Alza.Api.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alza.Api.Infrastructure.Repository
{
    public class FakeProductRepository : IProductRepository
    {
        public ICollection<Product> FindAll()
        {
            var result = new List<Product>();
            result.Add(new Product
            {
                Id = 1,
                Description = "desc1",
                ImgUri = "/test1/test1/test1.png",
                Name = "name1",
                Price = 1.1M
            });
            result.Add(new Product
            {
                Id = 2,
                Description = "desc2",
                ImgUri = "/test2/test2/test2.png",
                Name = "name2",
                Price = 2.2M
            });

            return result;
        }

        public Product FindById(long id)
        {
            return new Product
            {
                Id = 1,
                Description = "desc1",
                ImgUri = "/test1/test1/test1.png",
                Name = "name1",
                Price = 1.1M
            };
        }

        public void Remove(Product entity)
        {
        }
    }
}
