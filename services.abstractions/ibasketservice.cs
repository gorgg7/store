using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;
using shared;

namespace services.abstractions
{
    public interface ibasketservice
    {
        Task<basketdto> getbasketasync(string id);
        Task<basketdto> updatebasketasync(customerbasket basket);
        Task<bool> Deletebasketasync(string id);
    }
}
