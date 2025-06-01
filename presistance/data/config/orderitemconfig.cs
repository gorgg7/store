using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.orderentities;
using Microsoft.EntityFrameworkCore;

namespace presistance.data.config
{
    public class orderitemconfig : IEntityTypeConfiguration<orderitem>
    {
        

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<orderitem> builder)
        {
            builder.OwnsOne(o => o.product, p=> p.WithOwner());

        }
    }
    
}
