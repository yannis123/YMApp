
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YMApp.ECommerce.Trips;

namespace  YMApp.ECommerce.Trips.Dtos
{
    public class TripEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// CategoryId
		/// </summary>
		public long CategoryId { get; set; }



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
		/// Price
		/// </summary>
		public decimal Price { get; set; }




    }
}