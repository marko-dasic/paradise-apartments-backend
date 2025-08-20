using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.DataAccess.Configuration
{
    public abstract class BaseConfigure<T> : IEntityTypeConfiguration<T> where T:Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            ConfigureEntity(builder);

        }

        public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
    
}
