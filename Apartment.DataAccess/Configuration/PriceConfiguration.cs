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
    public class PriceConfiguration : BaseConfigure<Apartment.Domain.Entities.Price>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Price> builder)
        {
            builder.Property(x => x.PricePerNight).IsRequired();
            builder.Property(x => x.PriceOnHoliday).IsRequired();
            builder.Property(x=> x.PriceOnNewYear).IsRequired();
            builder.Property(x => x.ApartmentId).IsRequired();

            builder.HasIndex(x => x.ApartmentId);
  
        }

    }
}
