using System;
using System.ComponentModel.DataAnnotations;

namespace YMApp.Categorys.Dtos
{
    public class CreateOrUpdateCategoryInput
    {
        [Required]
        public CategoryEditDto Category { get; set; }
    }
}
