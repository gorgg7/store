using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;
using shared;

namespace services.mapping
{
    public class basketprofile : AutoMapper.Profile
    {
        public basketprofile()
        {
          CreateMap<customerbasket,basketdto>().ReverseMap();
            CreateMap<basketitem, basketitemdto>().ReverseMap();
        }
    }
    
}
