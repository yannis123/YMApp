using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace YMApp.ECommerce.ProductAttributes
{
    public class ProductAttribute : Entity<long>, IHasCreationTime, IDeletionAudited, ICreationAudited, IModificationAudited, IMustHaveTenant
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        /// <value>The product identifier.</value>
        public long ProductId { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        /// <value>The field value.</value>
        public string FieldValue { get; set; }

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
