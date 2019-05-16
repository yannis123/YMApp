using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace YMApp.ECommerce.ProductFields
{
    public class ProductField : Entity<long>, IHasCreationTime, IDeletionAudited, ICreationAudited, IModificationAudited, IMustHaveTenant
    {
        /// <summary>
        /// 产品类型
        /// </summary>
        /// <value>The product type.</value>
        public int ProductType { get; set; }

        /// <summary>
        /// 参数级别 
        /// </summary>
        public int FieldGrade { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }

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
