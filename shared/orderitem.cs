using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.orderdto
{
    public class orderitem
    {
        public int id;
        public string productname { get; set; }
        public string producturl { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
    }
}
