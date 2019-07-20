using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using YMApp.Controllers;
using YMApp.Web.Admin.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMApp.Web.Admin.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class PicturesController : YMAppControllerBase
    {
        private IHostingEnvironment hostingEnv;

        string[] pictureFormatArray = { "png", "jpg", "jpeg", "bmp", "gif", "ico", "PNG", "JPG", "JPEG", "BMP", "GIF", "ICO" };

        public PicturesController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpPost]
        public JsonResult Post()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            //size > 100MB refuse upload !
            if (size > 104857600)
            {
                return Json(FileUploadResult.Error_Msg_Ecode_Elevel_HttpCode("pictures total size > 100MB , server refused !"));
            }

            List<FileModel> fileList = new List<FileModel>();
            foreach (var file in files)
            {
                var oldfileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string filePath = hostingEnv.WebRootPath + $@"\Files\Pictures\";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string suffix = oldfileName.Split('.')[1];

                if (!pictureFormatArray.Contains(suffix))
                {
                    return Json(FileUploadResult.Error_Msg_Ecode_Elevel_HttpCode("the picture format not support ! you must upload files that suffix like 'png','jpg','jpeg','bmp','gif','ico'."));
                }

                string fileName = Guid.NewGuid() + "." + suffix;

                string fileFullName = filePath + fileName;

                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                FileModel model = new FileModel()
                {
                    FileName = oldfileName,
                    FileSize = file.Length.ToString(),
                    FilePath = $"/Files/Pictures/{fileName}"
                };
                fileList.Add(model);
            }

            string message = $"{files.Count} file(s) /{size} bytes uploaded successfully!";

            return Json(FileUploadResult.Success_Msg_Data_DCount_HttpCode(message, fileList, fileList.Count));
        }

    }
}
