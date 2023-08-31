﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // modelBuilder.Entity<Category>().HasKey(x=>x.Id).HasName("categoryId");
            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature { Id = 1, ProductId = 1, Color = "kırmızı1", Height = 100, Width = 10 },
                new ProductFeature { Id = 2, ProductId = 2, Color = "kırmızı2", Height = 100, Width = 10 },
                new ProductFeature { Id = 3, ProductId = 3, Color = "kırmızı3", Height = 100, Width = 10 },
                new ProductFeature { Id = 4, ProductId = 4, Color = "kırmızı4", Height = 100, Width = 10 },
                new ProductFeature { Id = 5, ProductId = 5, Color = "kırmızı5", Height = 100, Width = 10 },
                new ProductFeature { Id = 6, ProductId = 6, Color = "kırmızı6", Height = 100, Width = 10 },
                new ProductFeature { Id = 7, ProductId = 7, Color = "kırmızı7", Height = 100, Width = 10 });


            base.OnModelCreating(modelBuilder);
        }
    }

}
