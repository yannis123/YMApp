
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YMApp.ECommerce.ProductFields;

namespace  YMApp.ECommerce.ProductFields.Dtos
{
    public class ProductFieldEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
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
        /// 上级参数Id
        /// </summary>
        public long ParentId { get; set; }

    }
}