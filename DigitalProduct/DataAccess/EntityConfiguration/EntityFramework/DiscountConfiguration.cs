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
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.Code).IsRequired(true).HasMaxLength(10);
            builder.Property(x => x.Rate).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);

            builder.HasIndex(x=>x.Code).IsUnique();
            builder.HasIndex(x=>x.UserId);

            builder.HasOne(x => x.Order).WithOne(x => x.Discount).HasForeignKey<Order>(x=>x.DiscountId);
            builder.HasOne(x => x.User).WithMany(x => x.Discounts).HasForeignKey(x => x.UserId);
        }
    }
}
