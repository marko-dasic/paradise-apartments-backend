using Microsoft.EntityFrameworkCore;
using Apartment.Domain.Entities;
using System;
using System.Linq.Expressions;
using EntityFrameworkExtension.Extensions;

namespace Apartment.DataAccess
{
    public class ApartmentContext : DbContext
    {
        
        public ApartmentContext() { }
        public ApartmentContext(DbContextOptions modelBuilder) :base (modelBuilder)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=localhost; Initial Catalog = apartment_djole; User Id = ???; Password =???#;TrustServerCertificate=True;MultipleActiveResultSets=true;");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApartmentContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(SoftDelete.GetSoftDeleteFilter(entityType.ClrType));
            }

            base.OnModelCreating(modelBuilder);
       
        }
    
        public override int SaveChanges()
        {
            this.ChangeTracker.SetAuditProperties();
            return base.SaveChanges();
        }

        public DbSet<Apartment.Domain.Entities.Apartment> Apartments { get; set; }
        public DbSet<ApartmentSpecification> ApartmentSpecifications{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<File> Files{ get; set; }
        public DbSet<Image> Images{ get; set; }
        public DbSet<Price> Prices{ get; set; }
        public DbSet<SpecPrice> SpecPrices{ get; set; }
        public DbSet<Rate> Rates{ get; set; }
        public DbSet<Report> Reports{ get; set; }
        public DbSet<ReportLine> ReportLines{ get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
		public DbSet<Room> Rooms { get; set; }
        public DbSet<Blog> Blogs{get;set;}
       // public DbSet<Role> Roles{ get; set; }
       //public DbSet<RoleUseCase> RoleUseCases{ get; set; }
        public DbSet<Specification> Specifications{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserUseCase> UserUseCase{ get; set; }
        public DbSet<UseCaseLog> UseCaseLogs{ get; set; }
    }
}
