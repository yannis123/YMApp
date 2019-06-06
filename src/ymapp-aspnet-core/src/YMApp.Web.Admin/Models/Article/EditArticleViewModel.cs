using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMApp.Categorys.Dtos;
using YMApp.ECommerce.Articles.Dtos;

namespace YMApp.Web.Admin.Models.Article
{
    public class EditArticleViewModel
    {
        public List<CategoryListDto> Categorys { get; set; }
        public ArticleEditDto Article { get; set; }
    }
}
