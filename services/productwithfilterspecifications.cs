using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using domain.contracts;
using domain.entites;
using shared;


namespace services.specifications
{
    public class Productwithfilterspecifications : specification<product>
    {
        public Productwithfilterspecifications(int id) : base(product => product.Id == id)
        {
            AddInclude(x => x.producttypee);
            AddInclude(x => x.productbrand);
        }
        public Productwithfilterspecifications(productspecparameters specs) : base(product =>
        (!specs.BrandId.HasValue || product.BrandId == specs.BrandId) &&
       (!specs.TypeId.HasValue || product.TypeId == specs.TypeId) &&
        (string.IsNullOrEmpty(specs.search) || product.Name.ToLower().Contains(specs.search.ToLower())))
        {


            {
                AddInclude(x => x.producttypee);
                AddInclude(x => x.productbrand);
            }
        }
    }
}