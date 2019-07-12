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
using YMApp.DocManage.Documents;
using YMApp.Web.Admin.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMApp.Web.Admin.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class FilesController : YMAppControllerBase
    {
        IDocumentAppService _documentAppService;
        private IHostingEnvironment hostingEnv;

        public FilesController(IHostingEnvironment env, IDocumentAppService documentAppService)
        {
            this.hostingEnv = env;
            _documentAppService = documentAppService;
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

        [HttpGet]
        public async Task<IActionResult> Download(Nullable<long> id)
        {
            try
            {
                var doc = await _documentAppService.GetById(new Abp.Application.Services.Dto.EntityDto<long>() { Id = id.Value });
                if (doc != null && !string.IsNullOrEmpty(doc.FilePath))
                {
                    var addrUrl = Directory.GetCurrentDirectory() + "/wwwroot" + doc.FilePath;
                    FileStream fs = new FileStream(addrUrl, FileMode.Open);
                    return File(fs, "application/octet-tream", doc.OriName);
                }
                else
                {
                    return Content("文件不存在");
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
