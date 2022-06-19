﻿using AspnetRun.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetRun.Infrastructure.Data
{
    public class appContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public appContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<User> Users { get; set; }
        public DbSet<CourtType> courtTypes { get; set; }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Product>(ConfigureProduct);
        //    builder.Entity<Category>(ConfigureCategory);
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
