using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entites
{
    public abstract class baseentity<TKEY> 
    {
        public TKEY Id { get; set; }

        //public DateTime? CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public DateTime? deletedat { get; set; }
        //public bool? IsAcIsDeletedtive { get; set; }
    }
}
