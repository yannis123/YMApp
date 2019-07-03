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
    public class FilesController : YMAppControllerBase
    {
        private IHostingEnvironment hostingEnv;

        public FilesController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }
        public JsonResult Upload()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            //size > 100MB refuse upload !
            if (size > 104857600)
            {
                return Json(FileUploadResult.Error_Msg_Ecode_Elevel_HttpCode("files total size > 100MB , server refused !"));
            }

            List<FileModel> fileList = new List<FileModel>();

            foreach (var file in files)
            {
                var oldfileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string filePath = hostingEnv.WebRootPath + $@"\Files\Files\";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string fileName = Guid.NewGuid() + "." + oldfileName.Split('.')[1];

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
                    FilePath = $"/Files/Files/{fileName}"
                };
                fileList.Add(model);
            }

            string message = $"{files.Count} file(s) /{size} bytes uploaded successfully!";

            return Json(FileUploadResult.Success_Msg_Data_DCount_HttpCode(message, fileList, fileList.Count));
        }

    }
}
