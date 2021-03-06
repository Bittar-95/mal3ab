using AspnetRun.Core.Entities;
using AspnetRun.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetRun.Infrastructure.Data
{
    public class appContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        //private readonly DbContextOptions _options;

        public appContext(DbContextOptions options) : base(options)
        {
            //_options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().Property(nameof(Reservation.Status)).HasDefaultValue(ReservationStatus.Pending);
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<User> Users { get; set; }
        public DbSet<CourtType> CourtTypes { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //builder.Entity<Reservation>().Property(nameof(Reservation.Status)).HasDefaultValue(ReservationStatus.Pending);
        //    //builder.Entity<Category>(ConfigureCategory);
        //}

        //private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        //{
        //    builder.ToTable("Product");

        //    builder.HasKey(ci => ci.Id);         

        //    builder.Property(cb => cb.ProductName)
        //        .IsRequired()
        //        .HasMaxLength(100);
        //}

        //private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        //{
        //    builder.ToTable("Category");

        //    builder.HasKey(ci => ci.Id);            

        //    builder.Property(cb => cb.CategoryName)
        //        .IsRequired()
        //        .HasMaxLength(100);
        //}
    }
}
