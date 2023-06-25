using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration.EntityFramework
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(25);
            builder.Property(x => x.Url).IsRequired(true).HasMaxLength(100);

            builder.HasMany(x=>x.CategoryProducts).WithOne(x=>x.Category).HasForeignKey(x=>x.CategoryId).IsRequired(false);
        }
    }

}
