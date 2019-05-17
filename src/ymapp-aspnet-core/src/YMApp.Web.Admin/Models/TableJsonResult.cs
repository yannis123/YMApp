using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMApp.Web.Admin.Models
{
    public class TableJsonResult
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public object data { get; set; }
    }
}
