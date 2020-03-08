using Alza.Api.Core.DomainModel;
using Alza.Api.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Api.Infrastructure.Repository
{
    public class FakeProductRepository : IProductRepository
    {
        public void Add(Product entity)
        {
        }

        public Task AddAsync(Product entity)
        {
            return Task.CompletedTask;
        }

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

        public Task<List<Product>> FindAllAsync()
        {
            return Task.Run(() =>
            {
                return FindAll().ToList();
            });
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

        public Task<Product> FindByIdAsync(long id)
        {
            return Task.Run(() =>
            {
                return FindById(id);
            });
        }

        public void Remove(Product entity)
        {
        }
    }
}
