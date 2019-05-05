
using Abp.Runtime.Validation;
using YMApp.Dtos;
using YMApp.ECommerce.Pictures;

namespace YMApp.ECommerce.Pictures.Dtos
{
    public class GetPicturesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
