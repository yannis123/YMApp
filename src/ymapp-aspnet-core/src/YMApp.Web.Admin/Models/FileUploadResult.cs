using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace YMApp.Web.Admin.Models
{
    public abstract class FileUploadResult
    {
        public static object IsSuccess_Msg_Data_HttpCode(bool isSuccess, string msg, dynamic data, HttpStatusCode httpCode = HttpStatusCode.OK)
        {
            return new { isSuccess = isSuccess, msg = msg, httpCode = httpCode, data = data };
        }
        public static object Success_Msg_Data_DCount_HttpCode(string msg, dynamic data = null, int dataCount = 0, HttpStatusCode httpCode = HttpStatusCode.OK)
        {
            return new { isSuccess = true, msg = msg, httpCode = httpCode, data = data, dataCount = dataCount };
        }
        public static object Error_Msg_Ecode_Elevel_HttpCode(string msg, int errorCode = 0, int errorLevel = 0, HttpStatusCode httpCode = HttpStatusCode.InternalServerError)
        {
            return new { isSuccess = false, msg = msg, httpCode = httpCode, errorCode = errorCode, errorLevel = errorLevel };
        }
    }

    public class FileModel
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 文件原始名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize { get; set; }
    }
}
