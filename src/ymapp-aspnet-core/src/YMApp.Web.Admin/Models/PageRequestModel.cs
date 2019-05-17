using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMApp.Web.Admin.Models
{
    public class PageRequestModel
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页数据大小
        /// </summary>
        public int limit { get; set; }
    }
}
