using Alza.Api.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.Repository
{
    public interface IProductRepository : IRepository<Product, long>
    {
    }
}
