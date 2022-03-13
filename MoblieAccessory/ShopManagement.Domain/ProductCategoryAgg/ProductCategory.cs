using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntityBase
    {
        public string Name{ get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public string  MetaDescription { get; private set; }
        public string Keyword { get; private set; }
        public string Slug { get; private set; }
        public List<Product> Products { get; set; }

        public ProductCategory(string name, string picture, string pictureAlt, string pictureTitle, string description, string metaDescription, string keyword, string slug)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string description, string metaDescription, string keyword, string slug)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
        }


    }
}
