using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.DataAccess.Configuration
{
    public class SpecPriceConfiguration : BaseConfigure<Domain.Entities.SpecPrice>
    {
        public override void ConfigureEntity(EntityTypeBuilder<SpecPrice> builder)
        {
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=>x.ApartmentId).IsRequired();
            builder.HasIndex(x => x.ApartmentId);
        }
    }
}
