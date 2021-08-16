using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Description).IsRequired().HasColumnType("varchar(MAX)");
            builder.Property(p => p.Price).HasColumnType("money");
            builder.Property(p => p.PictureUrl).IsRequired().HasColumnType("varchar(200)");
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
        }
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(50)");
        }
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(50)");
        }
    }
}