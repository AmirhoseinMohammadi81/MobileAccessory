using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<int,ProductCategory>
    {
        List<ProductCategoryViewModel> Search(string name);
        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> GetProductCategory();
    }
}
