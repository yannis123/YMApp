

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Pictures;

namespace YMApp.ECommerce.Pictures.Dtos
{
    public class CreateOrUpdatePictureInput
    {
        [Required]
        public PictureEditDto Picture { get; set; }

    }
}