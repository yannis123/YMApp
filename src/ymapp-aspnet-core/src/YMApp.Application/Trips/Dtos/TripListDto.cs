﻿using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using YMApp.Categorys;
using YMApp.Categorys.Dtos;

namespace YMApp.Trips.Dtos
{
    public class TripListDto : EntityDto<long>, IHasCreationTime
    {
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
        /// 所属分类
        /// </summary>
        /// <value>The category.</value>
        public virtual CategoryListDto Category { get; set; }
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

        public DateTime CreationTime { get; set; }
    }
}
