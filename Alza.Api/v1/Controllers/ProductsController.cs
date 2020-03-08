using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alza.Api.Core.BussinessRule;
using Alza.Api.v1.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Alza.Api.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFacade productFacade;
        private readonly IMapper mapper;

        public ProductsController(IProductFacade productFacade, IMapper mapper)
        {
            this.productFacade = productFacade;
            this.mapper = mapper;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            var products = productFacade.GetProductsCollection();
            var productsResult = mapper.Map<List<ProductDTO>>(products).AsEnumerable();

            return Ok(productsResult);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> Get(int id)
        {
            var product = productFacade.GetProductById(id);
            var productResult = mapper.Map<ProductDTO>(product);

            return Ok(productResult);
        }

        // PATCH api/products/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] ProductPartialDTO product)
        {
            productFacade.UpdateProductDescription(id, product.Description);
        }
    }
}
