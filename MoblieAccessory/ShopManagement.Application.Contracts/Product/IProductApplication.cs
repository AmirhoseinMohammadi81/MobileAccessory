using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        IEnumerable<ProductViewModel> Search(string name);
        List<ProductSelectListModel> GetProducts();
        EditProduct GetDetails(int id);
        OperationResult InStock(int id);
        OperationResult NotInStock(int id);
    }
}
