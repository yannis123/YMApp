
using Abp.Runtime.Validation;
using System;
using YMApp.Application.Dtos;
using YMApp.ECommerce.Articles;

namespace YMApp.ECommerce.Articles.Dtos
{
    public class GetArticlesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        public string Title { get; set; }
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
