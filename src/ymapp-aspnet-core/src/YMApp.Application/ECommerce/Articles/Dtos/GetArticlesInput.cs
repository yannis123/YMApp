
using Abp.Runtime.Validation;
using YMApp.Application.Dtos;
using YMApp.ECommerce.Articles;

namespace YMApp.ECommerce.Articles.Dtos
{
    public class GetArticlesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
