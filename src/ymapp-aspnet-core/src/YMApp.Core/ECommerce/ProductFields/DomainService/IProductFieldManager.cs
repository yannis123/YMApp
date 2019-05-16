

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using YMApp.ECommerce.ProductFields;


namespace YMApp.ECommerce.ProductFields.DomainService
{
    public interface IProductFieldManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitProductField();



		 
      
         

    }
}
