using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using domain.contracts;
using domain.entites;
using services.abstractions;
using shared;

namespace services
{
    public class basketservice(ibasketrepo basketrepo,IMapper mapper) : ibasketservice
    {
        public async Task<bool> Deletebasketasync(string id)
        {
            return await basketrepo.Deletebasketasync(id);
        }

        public async Task<basketdto> getbasketasync(string id)
        {
            var basket = await basketrepo.getbasketasync(id);
            return basket is null? throw new Exception("basket not found"): mapper.Map<basketdto>(basket);
        }
        public async Task<basketdto> updatebasketasync(customerbasket basket)
        {
            var custmerbasket = mapper.Map<customerbasket>(basket);
            var updatedbasket = basketrepo.updatebasketasync(custmerbasket);
            return updatedbasket is null ? throw new Exception("cantupdate") : mapper.Map<basketdto>(updatedbasket);
        }
    }
}
