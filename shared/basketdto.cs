using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace shared
{
    public class basketdto
    {
        public string id { get; set; }
        public IEnumerable<basketitem> myproperty { get; set; }
    }
}
