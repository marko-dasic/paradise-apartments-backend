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
    public class ReportLineConfiguration : BaseConfigure<Apartment.Domain.Entities.ReportLine>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.ReportLine> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            

            builder.HasMany(x => x.Reports).WithOne(x=>x.ReportLine)
                .HasForeignKey(x=>x.ReportLineId);


        }

    }
}

