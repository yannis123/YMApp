

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using YMApp.ECommerce.Trips;


namespace YMApp.ECommerce.Trips.DomainService
{
    public interface ITripManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitTrip();



		 
      
         

    }
}
