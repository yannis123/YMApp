
using Abp.Runtime.Validation;
using YMApp.Application.Dtos;
using YMApp.ECommerce.ProductFields;

namespace YMApp.ECommerce.ProductFields.Dtos
{
    public class GetProductFieldsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
