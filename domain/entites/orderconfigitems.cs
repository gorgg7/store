using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace domain.orderentities
{
    public class orderconfigitems : IEntityTypeConfiguration<orderitem>
    {
        public void Configure(EntityTypeBuilder<orderitem> builder)
        {
            builder.OwnsOne(o => o.product, p=> p.WithOwner());

        }
    }

}
