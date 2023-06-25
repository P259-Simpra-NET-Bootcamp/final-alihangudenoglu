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
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.BasketId).IsRequired(true);
            builder.Property(x => x.ProductId).IsRequired(true);
            builder.Property(x => x.Quantity).IsRequired(true);


            builder.HasOne(x=>x.Product).WithOne(x=>x.BasketItem).HasForeignKey<BasketItem>(x=>x.ProductId);
        }
    }
}
