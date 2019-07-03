

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using YMApp;
using YMApp.DocManage.Documents;


namespace YMApp.DocManage.Documents.DomainService
{
    /// <summary>
    /// Document领域层的业务管理
    ///</summary>
    public class DocumentManager :YMAppDomainServiceBase, IDocumentManager
    {
		
		private readonly IRepository<Document,long> _repository;

		/// <summary>
		/// Document的构造方法
		///</summary>
		public DocumentManager(
			IRepository<Document, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitDocument()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
