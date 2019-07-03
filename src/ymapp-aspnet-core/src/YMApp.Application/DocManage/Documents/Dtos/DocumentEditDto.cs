
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YMApp.Categorys;
using YMApp.DocManage.Documents;

namespace  YMApp.DocManage.Documents.Dtos
{
    public class DocumentEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// Name
		/// </summary>
		[MaxLength(200, ErrorMessage="Name超出最大长度")]
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// CategoryId
		/// </summary>
		[Required(ErrorMessage="CategoryId不能为空")]
		public long CategoryId { get; set; }



		/// <summary>
		/// Describe
		/// </summary>
		[MaxLength(500, ErrorMessage="Describe超出最大长度")]
		public string Describe { get; set; }



		/// <summary>
		/// FileSize
		/// </summary>
		public string FileSize { get; set; }



		/// <summary>
		/// FilePath
		/// </summary>
		[MaxLength(200, ErrorMessage="FilePath超出最大长度")]
		[Required(ErrorMessage="FilePath不能为空")]
		public string FilePath { get; set; }



		/// <summary>
		/// State
		/// </summary>
		[Required(ErrorMessage="State不能为空")]
		public int State { get; set; }



		/// <summary>
		/// OriName
		/// </summary>
		public string OriName { get; set; }



		/// <summary>
		/// Category
		/// </summary>
		public Category Category { get; set; }




    }
}