using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;

namespace shared
{
    public class productdto
    {
        public int id;
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? PictureUrl { get; set; }
        public string Typename { get; set; }
        public string Brandname { get; set; }

    }
}
