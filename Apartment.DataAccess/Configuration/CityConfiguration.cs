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
    public class CityConfiguration : BaseConfigure<City>
    {
        public override void ConfigureEntity(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

          //  builder.HasIndex(x => x.Name).IsUnique(); ne mozemo imati unique index zbog soft deleta
            builder.HasMany(x => x.Users)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.Apartments)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);




        }



    }
}
