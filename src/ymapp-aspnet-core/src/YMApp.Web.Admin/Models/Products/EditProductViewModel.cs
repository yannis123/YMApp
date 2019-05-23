using System;
using System.Collections.Generic;
using YMApp.Categorys.Dtos;
using YMApp.ECommerce.ProductFields.Dtos;

namespace YMApp.Web.Admin.Models.Products
{
    public class EditProductViewModel
    {
        //public List<ProductFieldListDto> ProductFields { get; set; }

        public List<CategoryListDto> ProductFields { get; set; }

        public List<CategoryListDto> Categorys { get; set; }
    }
}
