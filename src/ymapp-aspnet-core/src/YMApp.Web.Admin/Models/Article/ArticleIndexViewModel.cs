using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMApp.Categorys.Dtos;

namespace YMApp.Web.Admin.Models.Article
{
    public class ArticleIndexViewModel
    {
        public List<CategoryListDto> Categorys { get; set; }
    }
}
