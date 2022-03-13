using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        List<ProductCategoryViewModel> Search(string name);
        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> GetProductCategory();

    }
}
