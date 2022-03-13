using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryMapping:IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(name: "ProductCategories", schema: "shop");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Picture).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MetaDescription).HasMaxLength(80);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Keyword).HasMaxLength(80);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.ProductCategory)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
