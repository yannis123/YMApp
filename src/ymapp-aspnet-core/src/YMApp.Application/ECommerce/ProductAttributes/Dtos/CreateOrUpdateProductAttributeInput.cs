

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.ProductAttributes;

namespace YMApp.ECommerce.ProductAttributes.Dtos
{
    public class CreateOrUpdateProductAttributeInput
    {
        [Required]
        public ProductAttributeEditDto ProductAttribute { get; set; }

    }
}