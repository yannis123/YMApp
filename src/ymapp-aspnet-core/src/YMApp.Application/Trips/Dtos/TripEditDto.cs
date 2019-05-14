using System;
using YMApp.Categorys;

namespace YMApp.Trips.Dtos
{
    public class TripEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 行程名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        /// <value>The category identifier.</value>
        public long CategoryId { get; set; }
        /// <summary>
        /// 封面图片
        /// </summary>
        /// <value>The picture URL.</value>
        public string PictureUrl { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        /// <value>The describe.</value>
        public string Describe { get; set; }
        /// <summary>
        /// 行程详情
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
        /// <summary>
        /// 行程状态 0 未审核 1 已审核
        /// </summary>
        /// <value>The state.</value>
        public int State { get; set; }
    }
}
