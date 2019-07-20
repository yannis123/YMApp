

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
using YMApp.ECommerce.Trips;


namespace YMApp.ECommerce.Trips.DomainService
{
    /// <summary>
    /// Trip领域层的业务管理
    ///</summary>
    public class TripManager :YMAppDomainServiceBase, ITripManager
    {
		
		private readonly IRepository<Trip,long> _repository;

		/// <summary>
		/// Trip的构造方法
		///</summary>
		public TripManager(
			IRepository<Trip, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitTrip()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
