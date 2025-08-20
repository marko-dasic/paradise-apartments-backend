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
    public class ResservationConfiguration : BaseConfigure<Apartment.Domain.Entities.Reservation>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Reservation> builder)
        {
            builder.Property(x => x.From).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.IsPaid).HasDefaultValue(false);
            builder.Property(x=>x.Cancelled).HasDefaultValue(false);
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.ApartmentId);


        }

    }
}

