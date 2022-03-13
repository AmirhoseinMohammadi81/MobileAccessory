using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore.context;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository:RepositoryBase<int,ProductCategory>,IProductCategoryRepository
    {
        private readonly ShopDbContext _shopContext;

        public ProductCategoryRepository(ShopDbContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductCategory GetDetails(int id)
        {
            return _shopContext.ProductCategories.Select(x => new EditProductCategory()
            {
                Id=x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                Keyword = x.Keyword,
                Description = x.Description,
                Slug = x.Slug,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategory()
        {
            return _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id=x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id=x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToShortDateString()
            });

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            return query.OrderBy(x => x.Id).ToList();
        }
    }
}
