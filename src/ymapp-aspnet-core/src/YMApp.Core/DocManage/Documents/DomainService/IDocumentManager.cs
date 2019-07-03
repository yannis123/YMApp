

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using YMApp.DocManage.Documents;


namespace YMApp.DocManage.Documents.DomainService
{
    public interface IDocumentManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitDocument();



		 
      
         

    }
}
