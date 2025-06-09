using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.orderdto
{
    public class orderrequest
    {
        public string basketid { get; set; }
        public addressdto shippingaddres { get; set; }
        public int deleverymethodid { get; set; }
        public string buyeremail { get; set; }
    }
}
