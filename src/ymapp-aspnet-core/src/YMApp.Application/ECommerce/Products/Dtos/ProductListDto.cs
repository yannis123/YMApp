

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Products;
using YMApp.Categorys;
using System.Collections.Generic;
using YMApp.ECommerce.Pictures;

namespace YMApp.ECommerce.Products.Dtos
{
    public class ProductListDto : EntityDto<long>,IHasCreationTime
    {

        
		/// <summary>
		/// CategoryId
		/// </summary>
		[Required(ErrorMessage="CategoryId不能为空")]
		public long CategoryId { get; set; }



		/// <summary>
		/// Category
		/// </summary>
		public Category Category { get; set; }



		/// <summary>
		/// Pictures
		/// </summary>
		public List<Picture> Pictures { get; set; }


		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// ProductCode
		/// </summary>
		public string ProductCode { get; set; }



		/// <summary>
		/// ProductName
		/// </summary>
		[MaxLength(100, ErrorMessage="ProductName超出最大长度")]
		[Required(ErrorMessage="ProductName不能为空")]
		public string ProductName { get; set; }



		/// <summary>
		/// Describe
		/// </summary>
		public string Describe { get; set; }



		/// <summary>
		/// State
		/// </summary>
		[Required(ErrorMessage="State不能为空")]
		public int State { get; set; }




    }
}