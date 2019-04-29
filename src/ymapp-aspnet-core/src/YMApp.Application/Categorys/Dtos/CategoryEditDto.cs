using System;
namespace YMApp.Categorys.Dtos
{
    public class CategoryEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }
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
        /// 排序
        /// </summary>
        /// <value>The sort.</value>
        public int Sort { get; set; }
    }
}
