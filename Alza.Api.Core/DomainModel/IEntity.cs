using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.DomainModel
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}
