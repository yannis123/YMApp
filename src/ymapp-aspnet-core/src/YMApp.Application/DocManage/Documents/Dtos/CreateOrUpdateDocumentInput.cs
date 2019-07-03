

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YMApp.DocManage.Documents;

namespace YMApp.DocManage.Documents.Dtos
{
    public class CreateOrUpdateDocumentInput
    {
        [Required]
        public DocumentEditDto Document { get; set; }

    }
}