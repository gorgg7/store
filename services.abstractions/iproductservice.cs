using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shared;

namespace services.abstractions
{
    public interface iproductservice
    {
        Task<IEnumerable<productdto>>GetProductdtos();
        Task<productdto> GetProductdto(int id);
        Task<IEnumerable<typedto>> GetProducttypedto();
        Task<IEnumerable<branddto>> GetProductbranddto();
    }
}
