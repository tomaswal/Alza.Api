using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.DomainModel
{
    public class Product : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImgUri{get; set;}
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
