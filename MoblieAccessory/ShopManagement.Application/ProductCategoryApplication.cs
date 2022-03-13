using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            var product = new ProductCategory(command.Name, command.Picture, command.PictureAlt,
            command.PictureTitle, command.Description, command.MetaDescription, command.Keyword, command.Slug);
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
            {
                return operation.Failed("دسته بندی مورد نظر تکراری است");
            }
            _productCategoryRepository.Create(product);
            _productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.GetBy(command.Id);
            if (productCategory==null)
            {
                return operation.Failed("رکوردی با این نام وجود ندارد");
            }
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name && x.Id != command.Id))
            {
                return operation.Failed("تکراری است");
            }

            productCategory.Edit(command.Name, command.Picture, command.PictureAlt,
            command.PictureTitle, command.Description, command.MetaDescription,
            command.Keyword, command.Slug);
            _productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategory()
        {
            return _productCategoryRepository.GetProductCategory();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return _productCategoryRepository.Search(name);
        }
    }
}
