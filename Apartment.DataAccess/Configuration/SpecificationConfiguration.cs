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
    public class SpecificationConfiguration : BaseConfigure<Apartment.Domain.Entities.Specification>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Specification> builder)
        {

            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.ApartmentSpecifications).WithOne(x => x.Specification)
                 .HasForeignKey(x => x.SpecificationId).OnDelete(DeleteBehavior.Restrict);


        }

    }
}

