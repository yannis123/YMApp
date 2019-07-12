
using Abp.Runtime.Validation;
using YMApp.DocManage.Documents;
using YMApp.Application.Dtos;
using System;

namespace YMApp.DocManage.Documents.Dtos
{
    public class GetDocumentsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        public string Name { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<long> CategoryId { get; set; }
        public Nullable<DateTime> Start { get; set; }
        public Nullable<DateTime> End { get; set; }

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
