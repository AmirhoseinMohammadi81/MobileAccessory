using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore.context;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<int, Product>, IProductRepository
    {
        private readonly ShopDbContext _shopContext;

        public ProductRepository( ShopDbContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
        public EditProduct GetDetails(int id)
        {
            return _shopContext.Products.Select(x => new EditProduct()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keyword = x.Keyword,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
            }
            ).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductSelectListModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductSelectListModel()
            {
                Id=x.Id,
                Name = x.Name,
            }).OrderBy(x=>x.Id).ToList();
        }

        public IEnumerable<ProductViewModel> Search(string name)
        {
            var query = _shopContext.Products.Select(x => new ProductViewModel()
            {
                Id=x.Id,
                Name = x.Name,
                Picture = x.Picture,
                IsInStock = x.IsInStock,
                CreationDate = x.CreationDate.ToShortDateString(),
                CategoryId = x.CategoryId,
            });

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            return query.OrderBy(x => x.Id).AsNoTracking().ToList();
        }
    }
}
