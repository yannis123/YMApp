

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.ProductFields;

namespace YMApp.ECommerce.ProductFields.Dtos
{
    public class CreateOrUpdateProductFieldInput
    {
        [Required]
        public ProductFieldEditDto ProductField { get; set; }

    }
}