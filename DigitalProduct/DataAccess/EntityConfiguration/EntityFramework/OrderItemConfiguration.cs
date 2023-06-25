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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.OrderId).IsRequired(true);
            builder.Property(x => x.ProductId).IsRequired(true);
            builder.Property(x => x.Quantity).IsRequired(true);


            builder.HasOne(x => x.Product).WithOne(x => x.OrderItem).HasForeignKey<OrderItem>(x => x.ProductId).IsRequired(false);
        }
    }
}
