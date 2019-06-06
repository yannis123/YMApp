using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMApp.Categorys.Dtos;

namespace YMApp.Web.Admin.Models.Category
{
    public class CategoryIndexViewModel
    {
        public IReadOnlyList<CategoryListDto> Categorys { get; set; }
    }
}
