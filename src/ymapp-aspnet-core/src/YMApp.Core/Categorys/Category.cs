using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace YMApp.Categorys
{
    public class Category : Entity<long>, IHasCreationTime, IDeletionAudited, ICreationAudited, IModificationAudited, IMustHaveTenant
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// 上级分类Id
        /// </summary>
        /// <value>The parent identifier.</value>
        public long ParentId { get; set; }
        /// <summary>
        /// 分类级别
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }
        /// <summary>
        /// 分类类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value>The sort.</value>
        public int Sort { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public int TenantId { get; set; }
    }
}
