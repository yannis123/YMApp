

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using YMApp.ECommerce.ProductAttributes;
using Abp.Domain.Entities;

namespace YMApp.ECommerce.ProductAttributes.Dtos
{
    public class ProductAttributeListDto : EntityDto<long>, IHasCreationTime
    {


        /// <summary>
        /// ProductId
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// FieldId
        /// </summary>
        public long FieldId { get; set; }

        /// <summary>
        /// FieldName
        /// </summary>
        public string FieldName { get; set; }



        /// <summary>
        /// FieldValue
        /// </summary>
        public string FieldValue { get; set; }

        /// <summary>
        /// …œº∂Id
        /// </summary>
        public long ParentId { get; set; }


        /// <summary>
        /// CreationTime
        /// </summary>
        public DateTime CreationTime { get; set; }



    }
}