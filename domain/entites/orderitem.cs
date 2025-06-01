using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace domain.orderentities
{
    public class orderitem:baseentity<Guid>
    {
        public productinoerderitem product { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }


    }
}
