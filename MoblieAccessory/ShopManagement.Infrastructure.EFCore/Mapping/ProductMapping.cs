using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductMapping:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "Products", schema: "shop");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Picture).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MetaDescription).HasMaxLength(80);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Keyword).HasMaxLength(80);

            builder.HasOne(x => x.ProductCategory)
                .WithMany(x
                => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
