using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.orderentities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackExchange.Redis;

namespace presistance.data.config
{
    public class orderconfigs : IEntityTypeConfiguration<orderentity>
    {
        

        public void Configure(EntityTypeBuilder<orderentity> builder)
        {
            builder.OwnsOne(o => o.shippingaddres, ad => ad.WithOwner());
            builder.HasMany(o => o.orderitems).WithOne();
            builder.Property(o=>o.orderpaymentstatus).HasConversion(
                o => o.ToString(),
                o => (orderpaymentstatus)Enum.Parse(typeof(orderpaymentstatus), o)
            );

        }
    }
}
