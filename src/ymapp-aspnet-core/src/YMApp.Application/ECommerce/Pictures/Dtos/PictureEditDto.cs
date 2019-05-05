
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YMApp.ECommerce.Pictures;

namespace  YMApp.ECommerce.Pictures.Dtos
{
    public class PictureEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// Url
		/// </summary>
		[MaxLength(200, ErrorMessage="Url超出最大长度")]
		public string Url { get; set; }



		/// <summary>
		/// LinkUrl
		/// </summary>
		[MaxLength(200, ErrorMessage="LinkUrl超出最大长度")]
		public string LinkUrl { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		public int Type { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		[MaxLength(50, ErrorMessage="Name超出最大长度")]
		public string Name { get; set; }



		/// <summary>
		/// Sort
		/// </summary>
		public int Sort { get; set; }




    }
}