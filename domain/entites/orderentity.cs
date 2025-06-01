using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace domain.orderentities
{
    public class orderentity : baseentity<Guid>
    {
        public string buyeremail { get; set; }
        public address shippingaddres { get; set; }
        public ICollection<orderitem> orderitems { get; set; } = new List<orderitem>();

        public orderpaymentstatus orderpaymentstatus { get; set; } = orderpaymentstatus.pending;
        public delivery deliverymethod { get; set; }
        public int? deleverymethodid { get; set; }
        public DateTimeOffset orderdate { get; set; } = DateTimeOffset.Now;
        public decimal subtotal { get; set; }

    }
}
