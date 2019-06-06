

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Articles;

namespace YMApp.ECommerce.Articles.Dtos
{
    public class CreateOrUpdateArticleInput
    {
        [Required]
        public ArticleEditDto Article { get; set; }

    }
}