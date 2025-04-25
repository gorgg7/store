using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared
{
    public class basketitemdto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, double.MaxValue)]
        public double Price { get; set; }
        public string? PictureUrl { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        [Range(1, 10)]

        public int Quantity { get; set; }
    }
}
