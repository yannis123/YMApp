

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Pictures.Dtos;
using YMApp.ECommerce.ProductAttributes.Dtos;
using YMApp.ECommerce.Products;

namespace YMApp.ECommerce.Products.Dtos
{
    public class CreateOrUpdateProductInput
    {
        [Required]
        public ProductEditDto Product { get; set; }
        public List<PictureEditDto> Pictures { get; set; }
        public List<ProductAttributeEditDto> ProductAttributes { get; set; }
    }
}