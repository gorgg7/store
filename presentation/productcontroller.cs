using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using services.abstractions;
using shared;

namespace presentation.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class productcontroller : ControllerBase
    {
        private readonly Iservicemanagment servicemanager;

        public productcontroller(Iservicemanagment servicemanager)
        {
            this.servicemanager = servicemanager;
        }

        [HttpGet("gettallproducts")]
        public async Task<ActionResult<IEnumerable<productdto>>> GetAllProducts()
        {
            var products = await servicemanager.iproductservice.GetProductdtos();
            return Ok(products);
        }

        [HttpGet("product")]
        public async Task<ActionResult<productdto>> GetProduct(int id)
        {
            var product = await servicemanager.iproductservice.GetProductdto(id);
            return Ok(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<typedto>>> GetProductTypes()
        {
            var types = await servicemanager.iproductservice.GetProducttypedto();
            return Ok(types);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<branddto>>> GetProductBrands()
        {
            var brands = await servicemanager.iproductservice.GetProductbranddto();
            return Ok(brands);
        }
    }
}
