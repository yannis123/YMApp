
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YMApp.Categorys;
using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.Pictures.Dtos;
using YMApp.ECommerce.ProductAttributes;
using YMApp.ECommerce.ProductAttributes.Dtos;
using YMApp.ECommerce.Products;

namespace YMApp.ECommerce.Products.Dtos
{
    public class ProductEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }



        /// <summary>
        /// CategoryId
        /// </summary>
        [Required(ErrorMessage = "CategoryId不能为空")]
        public long CategoryId { get; set; }



        /// <summary>
        /// Pictures
        /// </summary>
        public List<PictureEditDto> Pictures { get; set; }



        /// <summary>
        /// ProductCode
        /// </summary>
        public string ProductCode { get; set; }



        /// <summary>
        /// ProductName
        /// </summary>
        [MaxLength(100, ErrorMessage = "ProductName超出最大长度")]
        [Required(ErrorMessage = "ProductName不能为空")]
        public string ProductName { get; set; }



        /// <summary>
        /// Describe
        /// </summary>
        public string Describe { get; set; }



        /// <summary>
        /// State
        /// </summary>
        [Required(ErrorMessage = "State不能为空")]
        public int State { get; set; }

        /// <summary>
        /// 产品参数
        /// </summary>
        /// <value>The product attributes.</value>
        public List<ProductAttributeEditDto> ProductAttributes { get; set; }


    }
}