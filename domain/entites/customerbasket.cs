﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entites
{
    public class customerbasket
    {
       public string id { get; set; }
        public IEnumerable<basketitem> myproperty { get; set; }
    }
}
