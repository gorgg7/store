using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using domain.entites;
using shared;

namespace services.mapping
{
    public class imageurlresolver : IValueResolver<product, productdto, string>
    {
       


        public string Resolve(product source, productdto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source.PictureUrl))
                return string.Empty;

            return $"https://localhost:7097/{source.PictureUrl}";
        }
    }
}
