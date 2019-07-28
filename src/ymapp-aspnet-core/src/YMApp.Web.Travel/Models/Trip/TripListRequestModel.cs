using System;
namespace YMApp.Web.Travel.Models.Trip
{
    public class TripListRequestModel
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        /// <value>The category identifier.</value>
        public long CategoryId { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex { get; set; }

    }
}
