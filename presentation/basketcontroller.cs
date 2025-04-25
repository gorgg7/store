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
    public class basketcontroller(Iservicemanagment servicemanagment) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBasket(string id)
        {
            var basket = await servicemanagment.ibasketservice.getbasketasync(id);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<basketdto>> UpdateBasket(basketdto basketdto)
        {
            await servicemanagment.ibasketservice.updatebasketasync(basketdto);
            return Ok(basketdto);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasket(string id)
        {
            await servicemanagment.ibasketservice.Deletebasketasync(id);
            return NoContent();
        }
    }
}
