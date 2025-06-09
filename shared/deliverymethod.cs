using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.orderdto
{
    public class deliverymethod
    {
        public int Id { get; set; }
        public string shortname { get; set; }
        public string description { get; set; }
        public string deliverytime { get; set; }
        public decimal price { get; set; }
    }
}
