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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(30);

            //builder.HasNoKey();
            //builder.HasKey(x => x.Id);

        }
    }
}
