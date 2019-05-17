using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMApp.Web.Admin.Models
{
    public class AjaxJsonResult
    {
        public AjaxJsonResult(int code, object data, string error)
        {
            Code = code;
            Data = data;
            ErrorMsg = error;
        }
        public AjaxJsonResult(object data, string error)
        {
            Code = 0;
            Data = data;
            ErrorMsg = error;
        }
        public AjaxJsonResult(object data)
        {
            Code = 0;
            Data = data;
            ErrorMsg = string.Empty; ;
        }
        public int Code { get; set; }
        public object Data { get; set; }
        public string ErrorMsg { get; set; }
    }
}
