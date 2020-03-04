using Alza.Api.Core.DomainModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.ImgUri)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .HasData(new Product()
                {
                    Id = 1,
                    ImgUri = "/Images/notebook.png",
                    Name = "Notebook",
                    Description = "Beautiful notebook",
                    Price = 29_999.77m
                },
                new Product()
                {
                    Id = 2,
                    ImgUri = "/Images/mobile.png",
                    Name = "Mobile",
                    Description = "Old mobile",
                    Price = 1_999.99m
                });
        }
    }
}
