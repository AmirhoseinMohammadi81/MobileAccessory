using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Name { get;private set; }
        public string Picture { get;private set; }
        public string PictureAlt { get;private set; }
        public string PictureTitle { get;private set; }
        public bool IsInStock { get; set; }
        public string Description { get;private set; }
        public string MetaDescription { get;private set; }
        public string Keyword { get;private set; }
        public string Slug { get;private set; }
        public int CategoryId { get;private set; }
        public ProductCategory ProductCategory { get; set; }

        public Product(string name, string picture, string pictureAlt, string pictureTitle
            , string description, string metaDescription, string keyword, string slug, int categoryId)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
            CategoryId = categoryId;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle
            , string description, string metaDescription, string keyword, string slug, int categoryId)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
            CategoryId = categoryId;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }
    }
}
