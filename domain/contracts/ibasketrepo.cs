using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace domain.contracts
{
    public interface ibasketrepo
    {
        Task <customerbasket> getbasketasync(string id);
        Task<customerbasket> updatebasketasync(customerbasket basket,TimeSpan? timeSpan=null);
        Task<bool> Deletebasketasync(string id);

    }
}
