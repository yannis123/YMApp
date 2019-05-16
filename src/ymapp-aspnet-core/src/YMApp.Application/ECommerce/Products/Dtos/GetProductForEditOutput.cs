

using System.Collections.Generic;
using Abp.Application.Services.Dto;
using YMApp.ECommerce.Pictures.Dtos;
using YMApp.ECommerce.ProductAttributes.Dtos;
using YMApp.ECommerce.Products;

namespace YMApp.ECommerce.Products.Dtos
{
    public class GetProductForEditOutput
    {

        public ProductEditDto Product { get; set; }
        public List<PictureEditDto> Pictures { get; set; }
        public List<ProductAttributeEditDto> ProductAttributes { get; set; }
    }
}