using Alza.Api.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void SaveChanges()
        {
            appDbContext.SaveChanges();
        }
    }
}
