using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entites;
using Microsoft.EntityFrameworkCore;

namespace presistance.data
{
    public class storedbcontext : DbContext
    {
        public storedbcontext(DbContextOptions<storedbcontext>options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(storedbcontext).Assembly);
        }
        
        public DbSet<product> products { get; set; }
        public DbSet<productbrand> productbrands { get; set; }
        public DbSet<producttype> producttypes { get; set; }


    }
   
}
