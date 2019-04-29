using System;
using Abp.Configuration;
using Abp.Runtime.Validation;
using Cloud.BookList.Dtos;

namespace YMApp.Categorys.Dtos
{

    public class GetCategorysInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
