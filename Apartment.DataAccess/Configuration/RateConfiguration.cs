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
    public class RateConfiguration : BaseConfigure<Apartment.Domain.Entities.Rate>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Rate> builder)
        {
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ApartmentId).IsRequired();

            builder.HasIndex(x => x.ApartmentId);
            builder.HasIndex(x => x.UserId);

        }

    }
}
