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
    public class FileConfiguration : BaseConfigure<Apartment.Domain.Entities.File>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.File> builder)
        {
            builder.Property(x => x.Path).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Alt).HasMaxLength(5000).IsRequired();
            builder.Property(x => x.Extension).IsRequired();
            builder.Property(x => x.Size).IsRequired();
            
     
        }

    }
}
