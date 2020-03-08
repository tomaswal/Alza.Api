using Alza.Api.Core.DomainModel;
using Alza.Api.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Api.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(Product entity)
        {
            appDbContext.Products.Add(entity);
        }

        public Task AddAsync(Product entity)
        {
            return appDbContext.Products.AddAsync(entity);
        }

        public ICollection<Product> FindAll()
        {
            return appDbContext.Products.ToList();
        }

        public Task<List<Product>> FindAllAsync()
        {
            return appDbContext.Products.ToListAsync();
        }

        public Product FindById(long id)
        {
            return appDbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public Task<Product> FindByIdAsync(long id)
        {
            return appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Product entity)
        {
            appDbContext.Products.Remove(entity);
        }
    }
}
