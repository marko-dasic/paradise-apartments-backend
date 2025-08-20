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
    public class ApartmentConfiguration : BaseConfigure<Apartment.Domain.Entities.Apartment>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Domain.Entities.Apartment> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(5000).IsRequired();
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.Surface).HasDefaultValue(50);
            builder.Property(x=>x.RoomId).IsRequired();
            builder.Property(x => x.WiFi).HasDefaultValue(false);
            builder.Property(x => x.Garage).HasDefaultValue(false);
            builder.Property(x => x.Floor).HasDefaultValue("Prizemlje");


            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.FileId);
            builder.HasIndex(x => x.CategoryId);
            builder.HasIndex(x => x.CityId);



            builder.HasMany(x => x.ApartmentSpecifications)
                .WithOne(x => x.Apartment)
                .HasForeignKey(x => x.ApartmentId).OnDelete(DeleteBehavior.Restrict);
       

            builder.HasMany(x => x.Reports)
                .WithOne(x => x.Apartment)
                .HasForeignKey(x => x.ApartmentId).OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.Rates)
            .WithOne(x => x.Apartment)
            .HasForeignKey(x => x.ApartmentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Comments)
            .WithOne(x => x.Apartment)
            .HasForeignKey(x => x.AppartmentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Images)
            .WithOne(x => x.Apartment)
            .HasForeignKey(x => x.ApartmentId).OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.Prices)
            .WithOne(x => x.Apartment)
            .HasForeignKey(x => x.ApartmentId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.SpecPrices)
            .WithOne(x => x.Apartment)
            .HasForeignKey(x => x.ApartmentId).OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(x => x.Reservations)
           .WithOne(x => x.Apartment)
           .HasForeignKey(x => x.ApartmentId).OnDelete(DeleteBehavior.Restrict);













        }



    }
}
