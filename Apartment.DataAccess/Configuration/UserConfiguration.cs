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
    public class UserConfiguration : BaseConfigure<Apartment.Domain.Entities.User>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.User> builder)
        {

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(30).IsRequired();

           // builder.HasIndex(x => x.Email).IsUnique(); ne mozemo imati unique index zbog soft delete
            

            builder.HasMany(x => x.Reports).WithOne(x => x.User)
                 .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Comments).WithOne(x => x.Author)
                 .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Rates).WithOne(x => x.Author)
                 .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Reservations).WithOne(x => x.User)
                 .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UseCases).WithOne(x => x.User)
                 .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);


        }

    }
}

