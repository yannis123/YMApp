

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using YMApp.ECommerce.Articles;


namespace YMApp.ECommerce.Articles.DomainService
{
    public interface IArticleManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitArticle();



		 
      
         

    }
}
