using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 2, Name = "urun1", Stock = 10, Price = 15, createdDate = DateTime.Now },
                new Product { Id = 2, CategoryId = 1, Name = "urun2", Stock = 10, Price = 15, createdDate = DateTime.Now },
                new Product { Id = 3, CategoryId = 3, Name = "urun3", Stock = 10, Price = 15, createdDate = DateTime.Now },
                new Product { Id = 4, CategoryId = 2, Name = "urun4", Stock = 10, Price = 15, createdDate = DateTime.Now },
                new Product { Id = 5, CategoryId = 1, Name = "urun5", Stock = 10, Price = 15, createdDate = DateTime.Now },
                new Product { Id = 6, CategoryId = 3, Name = "urun6", Stock = 10, Price = 15, createdDate = DateTime.Now },
                new Product { Id = 7, CategoryId = 2, Name = "urun7", Stock = 10, Price = 15, createdDate = DateTime.Now }
                );
        }
    }
}
