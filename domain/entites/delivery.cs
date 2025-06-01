using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace domain.orderentities
{
    public class delivery:baseentity<int>
    {
        public string shortname { get; set; }
        public string description { get; set; }
        public string deliverytime { get; set; }
        public decimal price { get; set; }
    }
}
