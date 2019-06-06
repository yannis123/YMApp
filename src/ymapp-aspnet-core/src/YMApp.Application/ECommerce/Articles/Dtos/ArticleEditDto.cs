
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YMApp.ECommerce.Articles;

namespace  YMApp.ECommerce.Articles.Dtos
{
    public class ArticleEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// CategoryId
		/// </summary>
		[Required(ErrorMessage="CategoryId不能为空")]
		public long CategoryId { get; set; }



		/// <summary>
		/// Title
		/// </summary>
		[MaxLength(200, ErrorMessage="Title超出最大长度")]
		[Required(ErrorMessage="Title不能为空")]
		public string Title { get; set; }



		/// <summary>
		/// Author
		/// </summary>
		[MaxLength(50, ErrorMessage="Author超出最大长度")]
		public string Author { get; set; }



		/// <summary>
		/// TextContent
		/// </summary>
		public string TextContent { get; set; }



		/// <summary>
		/// Source
		/// </summary>
		[MaxLength(50, ErrorMessage="Source超出最大长度")]
		public string Source { get; set; }



		/// <summary>
		/// State
		/// </summary>
		public int State { get; set; }




    }
}