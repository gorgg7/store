using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.orderentities;

namespace shared.orderdto
{
    public class orderresult
    {
        public Guid id { get; set; }
        public string buyeremail { get; set; }
        public addressdto shippingaddres { get; set; }
        public ICollection<orderitem> orderitems { get; set; } = new List<orderitem>();

        public orderpaymentstatus orderpaymentstatus { get; set; } = orderpaymentstatus.pending;
        public string deliverymethod { get; set; }
        public int? deleverymethodid { get; set; }
        public DateTimeOffset orderdate { get; set; } 
        public decimal subtotal { get; set; }
    }
}
