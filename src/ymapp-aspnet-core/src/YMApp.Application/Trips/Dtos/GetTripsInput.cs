using System;
using Abp.Runtime.Validation;
using Cloud.BookList.Dtos;

namespace YMApp.Trips.Dtos
{
    public class GetTripsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
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
