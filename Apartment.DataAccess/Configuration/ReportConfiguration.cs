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
    public class ReportConfiguration : BaseConfigure<Apartment.Domain.Entities.Report>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Report> builder)
        {
            builder.Property(x => x.Text);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ApartmentId).IsRequired();

            builder.HasIndex(x => x.ApartmentId);
            builder.HasIndex(x => x.UserId);

        }

    }
}
