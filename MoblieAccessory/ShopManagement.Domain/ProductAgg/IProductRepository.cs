using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
   public interface IProductRepository:IRepository<int,Product>
   {
       IEnumerable<ProductViewModel> Search(string name);
       List<ProductSelectListModel> GetProducts();
       EditProduct GetDetails(int id);
   }
}
