using System;
namespace YMApp.Web.Admin.Models.Products
{
    public class GetProductByPageRequest : PageRequestModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
