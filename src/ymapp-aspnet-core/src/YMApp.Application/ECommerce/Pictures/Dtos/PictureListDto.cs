

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Pictures;

namespace YMApp.ECommerce.Pictures.Dtos
{
    public class PictureListDto : EntityDto<long>,IHasCreationTime,IDeletionAudited,ICreationAudited,IModificationAudited 
    {

        
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
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// Sort
		/// </summary>
		public int Sort { get; set; }




    }
}