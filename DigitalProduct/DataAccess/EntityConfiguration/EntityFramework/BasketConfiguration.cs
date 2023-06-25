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
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.DiscountId).IsRequired(false);
            builder.Property(x => x.TotalPrice).IsRequired(false).HasPrecision(15,2);
            builder.HasIndex(x => x.UserId);


            builder.HasMany(x => x.BasketItems).WithOne(x => x.Basket).HasForeignKey(x => x.BasketId);
        }
    }
}
