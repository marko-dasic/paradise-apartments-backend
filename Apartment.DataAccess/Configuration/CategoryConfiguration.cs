using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.DataAccess.Configuration
{
    public class CategoryConfiguration : BaseConfigure<Category>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.ParrentId);

            builder.HasMany(x=>x.Childrends)
                .WithOne(x=>x.Parrent)
                .HasForeignKey(x=>x.ParrentId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);


            builder.HasMany(x => x.Apartments)
                .WithOne(x => x.CategoryOfApartment)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);


        }
    }
}
