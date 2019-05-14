

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
using YMApp.ECommerce.Pictures;


namespace YMApp.ECommerce.Pictures.DomainService
{
    /// <summary>
    /// Picture领域层的业务管理
    ///</summary>
    public class PictureManager :YMAppDomainServiceBase, IPictureManager
    {
		
		private readonly IRepository<Picture,long> _repository;

		/// <summary>
		/// Picture的构造方法
		///</summary>
		public PictureManager(
			IRepository<Picture, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitPicture()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
