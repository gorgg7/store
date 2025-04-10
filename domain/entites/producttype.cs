using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entites
{
    public class producttype: baseentity<int>
    {
        public string Name { get; set; }
    }
}
