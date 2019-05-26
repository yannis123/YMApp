using System;
using System.Collections.Generic;
using YMApp.Categorys.Dtos;
using YMApp.ECommerce.ProductFields.Dtos;
using YMApp.ECommerce.Products.Dtos;

namespace YMApp.Web.Admin.Models.Products
{
    public class EditProductViewModel
    {
        public EditProductViewModel()
        {
            Pictutres = new List<string>();
            ProductFields = new List<ProductFieldListDto>();
            Categorys = new List<CategoryListDto>();
        }
        public ProductEditDto Product { get; set; }

        public List<string> Pictutres { get; set; }

        public List<ProductFieldListDto> ProductFields { get; set; }

        public List<CategoryListDto> Categorys { get; set; }
    }
}
