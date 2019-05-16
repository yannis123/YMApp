
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YMApp.ECommerce.ProductAttributes;

namespace  YMApp.ECommerce.ProductAttributes.Dtos
{
    public class ProductAttributeEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// ProductId
		/// </summary>
		public long ProductId { get; set; }



		/// <summary>
		/// FieldName
		/// </summary>
		public string FieldName { get; set; }



		/// <summary>
		/// FieldValue
		/// </summary>
		public string FieldValue { get; set; }

        /// <summary>
        /// 参数等级
        /// </summary>
        public int FieldGrade { get; set; }


    }
}