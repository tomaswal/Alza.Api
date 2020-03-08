using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.Repository
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
