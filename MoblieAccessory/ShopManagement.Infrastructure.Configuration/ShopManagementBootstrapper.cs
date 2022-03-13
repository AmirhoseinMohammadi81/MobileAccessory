using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Infrastructure.EFCore.Repository;
using System;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Application;
using ShopManagement.Infrastructure.EFCore.context;

namespace ShopManagement.Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryApplication, ProductCategoryApplication>();

            services.AddDbContext<ShopDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
