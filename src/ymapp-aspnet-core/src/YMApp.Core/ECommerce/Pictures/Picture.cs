using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace YMApp.ECommerce.Pictures
{
    public class Picture : Entity<long>, IHasCreationTime, IDeletionAudited, ICreationAudited, IModificationAudited
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图片链接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
