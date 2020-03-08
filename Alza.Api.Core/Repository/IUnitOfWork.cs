using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Api.Core.Repository
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
