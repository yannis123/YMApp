
using Abp.Runtime.Validation;
using YMApp.Application.Dtos;
using YMApp.ECommerce.ProductAttributes;

namespace YMApp.ECommerce.ProductAttributes.Dtos
{
    public class GetProductAttributesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
