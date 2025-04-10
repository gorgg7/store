using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entites
{
    public class product:baseentity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public producttype ProductType { get; set; }
        public productbrand ProductBrand { get; set; }

    }
    
}
