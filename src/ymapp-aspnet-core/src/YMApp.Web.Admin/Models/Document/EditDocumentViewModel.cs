using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMApp.Categorys.Dtos;
using YMApp.DocManage.Documents.Dtos;

namespace YMApp.Web.Admin.Models.Document
{
    public class EditDocumentViewModel
    {
        public List<CategoryListDto> Categorys { get; set; }
        public DocumentEditDto Document { get; set; }
    }
}
