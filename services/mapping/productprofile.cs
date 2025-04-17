using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.entites;
using System.Threading.Tasks;
using AutoMapper;

namespace services.mapping
{
    public class productprofile: Profile
    {
        public productprofile()
        {
            CreateMap<productbrand, shared.branddto>();
            CreateMap<producttype, shared.typedto>();

            CreateMap<product, shared.productdto>()
                .ForMember(d => d.Brandname, options => options.MapFrom(src => src.productbrand.Name))
                .ForMember(d => d.Typename, options => options.MapFrom(src => src.producttypee.Name));
        }
    }
        
}
