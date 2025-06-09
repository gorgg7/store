using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shared.orderdto;

namespace services.abstractions
{
    public interface iorderservice
    {
        Task<orderresult>GetOrderresult(Guid id);
        Task<IEnumerable<orderresult>> GetOrdersByBuyerEmail(string buyeremail);
        Task<orderresult> CreateOrder(orderrequest orderrequest);
        Task<IEnumerable<deliverymethod>> GetDeliverymethods();
    }
}
