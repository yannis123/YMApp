using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using YMApp.Categorys;

namespace YMApp.DocManage.Documents
{
    public class Document : Entity<long>, IHasCreationTime, IDeletionAudited, ICreationAudited, IModificationAudited, IMustHaveTenant
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 原始名称
        /// </summary>
        public string OriName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public string FileSize { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 状态 
        /// </summary>
        public int State { get; set; }

        public int TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
