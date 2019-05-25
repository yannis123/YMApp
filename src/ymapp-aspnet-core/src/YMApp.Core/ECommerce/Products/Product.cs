using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using YMApp.Categorys;
using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.ProductAttributes;
using YMApp.ECommerce.ProductFields;

namespace YMApp.ECommerce.Products
{
    public class Product : Entity<long>, IHasCreationTime, IDeletionAudited, ICreationAudited, IModificationAudited, IMustHaveTenant
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// 所属分类导航属性
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品图片列表
        /// </summary>
        public virtual List<Picture> Pictures { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 商品状态 1 已审核 2 未审核
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 产品参数
        /// </summary>
        /// <value>The product attributes.</value>
        public virtual List<ProductAttribute> ProductAttributes { get; set; }

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
