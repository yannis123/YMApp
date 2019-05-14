

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Products;

namespace YMApp.ECommerce.Products.Dtos
{
    public class CreateOrUpdateProductInput
    {
        [Required]
        public ProductEditDto Product { get; set; }

    }
}