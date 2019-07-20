

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.Trips;
using YMApp.Categorys;

namespace YMApp.ECommerce.Trips.Dtos
{
    public class TripListDto : EntityDto<long>,IHasCreationTime
    {

        
		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// CategoryId
		/// </summary>
		public long CategoryId { get; set; }



		/// <summary>
		/// Category
		/// </summary>
		public Category Category { get; set; }



		/// <summary>
		/// PictureUrl
		/// </summary>
		public string PictureUrl { get; set; }



		/// <summary>
		/// Describe
		/// </summary>
		public string Describe { get; set; }



		/// <summary>
		/// Content
		/// </summary>
		public string Content { get; set; }



		/// <summary>
		/// State
		/// </summary>
		public int State { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// Price
		/// </summary>
		public decimal Price { get; set; }




    }
}