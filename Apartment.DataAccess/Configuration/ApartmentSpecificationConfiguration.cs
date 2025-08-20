using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.DataAccess.Configuration
{
    public class ApartmentSpecificationConfiguration : BaseConfigure<ApartmentSpecification>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ApartmentSpecification> builder)
        {
            builder.Property(x => x.Value).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.SpecificationId);
            builder.HasIndex(x => x.ApartmentId); 

            

        }
    }
}
