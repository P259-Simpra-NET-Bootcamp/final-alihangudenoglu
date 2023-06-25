using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration.EntityFramework
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.DiscountId).IsRequired(false);
            builder.Property(x => x.BasketTotal).IsRequired(true).HasPrecision(15, 2);
            builder.Property(x => x.UsedPuan).IsRequired(false).HasPrecision(15, 2);
            builder.Property(x => x.GainedPuan).IsRequired(true).HasPrecision(15, 2);

           

            builder.HasOne(x=>x.User).WithMany(x=>x.Orders).HasForeignKey(x=>x.UserId);
            builder.HasMany(x=>x.OrderItems).WithOne(x=>x.Order).HasForeignKey(x=>x.OrderId);
            
        }
    }
}
