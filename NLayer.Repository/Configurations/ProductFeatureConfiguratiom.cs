using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entity;

namespace NLayer.Repository.Configurations
{
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Color).IsRequired();
            builder.Property(x => x.Width).IsRequired();
            builder.Property(x => x.Height).IsRequired();

            builder.HasOne(x => x.Product).WithOne(x => x.Feature).HasForeignKey<ProductFeature>(x => x.ProductId); //1:1

            builder.ToTable("ProductFeatures");

        }
    }
}
