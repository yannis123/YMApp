

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using YMApp;
using YMApp.ECommerce.Products;
using Abp.Domain.Entities;
using YMApp.Categorys;
using YMApp.ECommerce.Pictures;

namespace YMApp.ECommerce.Products.DomainService
{
    /// <summary>
    /// Product领域层的业务管理
    ///</summary>
    public class ProductManager : YMAppDomainServiceBase, IProductManager
    {

        private readonly IRepository<Product, long> _repository;
        private readonly IRepository<Category, long> _categoryRepository;
        private readonly IRepository<Picture, long> _pictureRepository;

        /// <summary>
        /// Product的构造方法
        ///</summary>
        public ProductManager(
            IRepository<Product, long> repository
            , IRepository<Category, long> categoryRepository
            , IRepository<Picture, long> pictureRepository
        )
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _pictureRepository = pictureRepository;
        }


        /// <summary>
        /// 初始化
        ///</summary>
        public void InitProduct()
        {
            throw new NotImplementedException();
        }

        // TODO:编写领域业务代码

        /// <summary>
        /// 获取商品详情 包含导航属性
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Product> GetByIdAsync(Entity<long> input)
        {
            var model = await _repository.GetAsync(input.Id);
            if (model.CategoryId > 0)
            {
                model.Category = await _categoryRepository.GetAsync(model.CategoryId);
            }
            model.Pictures = await _pictureRepository.GetAllListAsync(m => m.ProductId == model.Id);
            return model;
        }


    }
}
