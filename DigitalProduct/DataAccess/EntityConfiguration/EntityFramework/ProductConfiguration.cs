using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration.EntityFramework
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=>x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x=>x.Name).IsRequired(true).HasMaxLength(150);
            builder.Property(x=>x.Description).IsRequired(false).HasMaxLength(800);
            builder.Property(x=>x.Price).IsRequired(true).HasPrecision(15,2);
            builder.Property(x=>x.MaxPuan).IsRequired(true);
            builder.Property(x=>x.PuanPercent).IsRequired(true);
            builder.Property(x=>x.Guarantee).IsRequired(true).HasDefaultValue(true);
            builder.Property(x=>x.Status).IsRequired(true).HasDefaultValue(true);
            builder.Property(x=>x.Stock).IsRequired(true);

            builder.HasMany(x => x.CategoryProducts).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).IsRequired(false);
        }
    }
}
