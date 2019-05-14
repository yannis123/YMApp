

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Services;
using YMApp.ECommerce.Products;


namespace YMApp.ECommerce.Products.DomainService
{
    public interface IProductManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitProduct();

        Task<Product> GetByIdAsync(long id);

        Task UpdateAsync(Product input);
    }
}
