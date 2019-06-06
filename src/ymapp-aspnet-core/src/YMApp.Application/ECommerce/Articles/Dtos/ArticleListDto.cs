

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Articles;
using YMApp.Categorys;

namespace YMApp.ECommerce.Articles.Dtos
{
    public class ArticleListDto : EntityDto<long>,IHasCreationTime
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



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }




    }
}