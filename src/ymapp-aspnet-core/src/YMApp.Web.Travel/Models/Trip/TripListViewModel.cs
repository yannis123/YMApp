using System;
using System.Collections.Generic;
using YMApp.Categorys;
using YMApp.Categorys.Dtos;
using YMApp.ECommerce.Trips.Dtos;

namespace YMApp.Web.Travel.Models.Trip
{
    public class TripListViewModel
    {
        /// <summary>
        /// 分类
        /// </summary>
        public CategoryListDto Category { get; set; }
        /// <summary>
        /// 线路
        /// </summary>
        public List<TripListDto> Trips { get; set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
