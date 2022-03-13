using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore.Mapping;

namespace ShopManagement.Infrastructure.EFCore.context
{
    public class ShopDbContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
