

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.ProductFields;
using Abp.Domain.Entities;

namespace YMApp.ECommerce.ProductFields.Dtos
{
    public class ProductFieldListDto : EntityDto<long>,IHasCreationTime
    {

        
		/// <summary>
		/// ProductType
		/// </summary>
		public int ProductType { get; set; }

		/// <summary>
		/// FieldName
		/// </summary>
		public string FieldName { get; set; }

        /// <summary>
        /// 参数级别 
        /// </summary>
        public int FieldGrade { get; set; }

        /// <summary>
        /// CreationTime
        /// </summary>
        public DateTime CreationTime { get; set; }







    }
}