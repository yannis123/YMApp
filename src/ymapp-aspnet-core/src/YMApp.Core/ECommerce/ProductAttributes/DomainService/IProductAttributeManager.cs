

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using YMApp.ECommerce.ProductAttributes;


namespace YMApp.ECommerce.ProductAttributes.DomainService
{
    public interface IProductAttributeManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitProductAttribute();



		 
      
         

    }
}
