using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apartment.DataAccess.Configuration
{
    public class BlogConfiguration : BaseConfigure<Blog>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.GoogleMap).HasMaxLength(2000);
            builder.Property(x => x.Adress).HasMaxLength(500);
            builder.Property(x => x.Content).HasMaxLength(20000);
            builder.HasIndex(x => x.FileId);
            builder.HasOne(x=>x.File).WithOne().OnDelete(DeleteBehavior.Cascade);         

        }
    }
}