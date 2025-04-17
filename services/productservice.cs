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

    public class productservice(Iunitofwork unitofwork,IMapper mapper ) : iproductservice
    {

        public async Task<IEnumerable<branddto>> GetProductbranddto()
        {
            var brands = await unitofwork.GetRepository <productbrand, int> ().GetAllAsync();
            var mappedBrands = mapper.Map<IEnumerable<branddto>>(brands);
            return mappedBrands;
        }
        public async Task<productdto> GetProductdto(int id)
        {
            var productt = await unitofwork.GetRepository<product, int>().GetByIdAsync(id);
            var mappedproductt = mapper.Map<productdto>(productt);
            return mappedproductt;
        }

        public async Task<IEnumerable<productdto>> GetProductdtos()
        {
            var product = await unitofwork.GetRepository<product, int>().GetAllAsync();
            var mappedproduct = mapper.Map<IEnumerable<productdto>>(product);
            return mappedproduct;

        }

        public async Task<IEnumerable<typedto>> GetProducttypedto()
        {
            var types = await unitofwork.GetRepository<producttype, int>().GetAllAsync();
            var mappedtype = mapper.Map<IEnumerable<typedto>>(types);
            return mappedtype;

        }
    }
}
