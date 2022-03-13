using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            var product = new Product(command.Name,command.Picture,command.PictureAlt,command.PictureTitle,command.Description,
            command.MetaDescription,command.Keyword,command.Slug,command.CategoryId);
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("محصول مورد نظر تکراری است");

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(command.Id);
            if (product == null)
            {
                return operation.Failed("رکوردی با این نام وجود ندارد ");
            }

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed("رکورد تکراری است");
            }
            product.Edit(command.Name, command.Picture, command.PictureAlt, command.PictureTitle, command.Description,
                command.MetaDescription, command.Keyword, command.Slug, command.CategoryId);
            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProduct GetDetails(int id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductSelectListModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OperationResult InStock(int id)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);
            if (product==null)
            {
                return operation.Failed("رکوردی وجود ندارد");
            }
            product.InStock();
            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult NotInStock(int id)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);
            if (product == null)
            {
                return operation.Failed("رکوردی وجود ندارد");
            }
            product.NotInStock();
            _productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public IEnumerable<ProductViewModel> Search(string name)
        {
            return _productRepository.Search(name);
        }
    }
}
