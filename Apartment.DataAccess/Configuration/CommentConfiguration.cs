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
    public class CommentConfiguration : BaseConfigure<Comment>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Comment> builder)
        {
            builder.Property(x => x.Text).HasMaxLength(5000).IsRequired();
         

            builder.HasIndex(x => x.AppartmentId);
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.ParrentId);

            builder.HasMany(x => x.ChildComments)
                .WithOne(x => x.Parrent)
                .HasForeignKey(x => x.ParrentId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}
