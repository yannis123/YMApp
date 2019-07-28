using System.Collections.Generic;
using Abp.Application.Navigation;
using YMApp.Categorys.Dtos;

namespace YMApp.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewModel
    {
        public List<CategoryListDto> Categorys { get; set; }
    }
}
