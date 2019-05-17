using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using YMApp.Categorys;
using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.Pictures.Dtos;
using YMApp.ECommerce.ProductAttributes;
using YMApp.ECommerce.ProductAttributes.Dtos;
using YMApp.ECommerce.Products.Authorization;
using YMApp.ECommerce.Products.DomainService;
using YMApp.ECommerce.Products.Dtos;

namespace YMApp.ECommerce.Products
{
    /// <summary>
    /// Product应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ProductAppService : YMAppAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, long> _entityRepository;
        private readonly IRepository<Picture, long> _pictureRepository;
        private readonly IRepository<ProductAttribute, long> _attributeRepository;
        private readonly IProductManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProductAppService(
        IRepository<Product, long> entityRepository
        , IProductManager entityManager
            , IRepository<Picture, long> pictureRepository
            , IRepository<ProductAttribute, long> attributeRepository
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
            _pictureRepository = pictureRepository;
            _attributeRepository = attributeRepository;
        }


        /// <summary>
        /// 获取Product的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(ProductPermissions.Query)]
        public async Task<PagedResultDto<ProductListDto>> GetPaged(GetProductsInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                .Include(m => m.Pictures)
                .Include(m => m.Category)
                .Include(m => m.ProductAttributes)
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<ProductListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<ProductListDto>>();

            return new PagedResultDto<ProductListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取ProductListDto信息
        /// </summary>
        [AbpAuthorize(ProductPermissions.Query)]
        public async Task<ProductListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityManager.GetByIdAsync(input.Id);
            return entity.MapTo<ProductListDto>();
        }

        /// <summary>
        /// 获取编辑 Product
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ProductPermissions.Create, ProductPermissions.Edit)]
        public async Task<GetProductForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetProductForEditOutput();
            ProductEditDto editDto;

            if (input.Id.HasValue)
            {
                //var entity = await _entityRepository.GetAsync(input.Id.Value);
                var entity = await _entityManager.GetByIdAsync(input.Id.Value);
                editDto = entity.MapTo<ProductEditDto>();

                var pictures = await _pictureRepository.GetAllListAsync(m => m.ProductId == entity.Id);
                output.Pictures = pictures.MapTo<List<PictureEditDto>>();

                var attributes = await _attributeRepository.GetAllListAsync(m => m.ProductId == entity.Id);
                output.ProductAttributes = attributes.MapTo<List<ProductAttributeEditDto>>();
            }
            else
            {
                editDto = new ProductEditDto();
            }

            output.Product = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Product的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ProductPermissions.Create, ProductPermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateProductInput input)
        {

            if (input.Product.Id.HasValue)
            {
                await Update(input);
            }
            else
            {
                await Create(input);
            }
        }


        /// <summary>
        /// 新增Product
        /// </summary>
        [AbpAuthorize(ProductPermissions.Create)]
        protected virtual async Task<ProductEditDto> Create(CreateOrUpdateProductInput input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Product>(input);
            var entity = input.Product.MapTo<Product>();

            entity = await _entityRepository.InsertAsync(entity);

            if (input.Pictures != null && input.Pictures.Count > 0)
            {
                foreach (var item in input.Pictures)
                {
                    item.ProductId = entity.Id;
                    await _pictureRepository.InsertAsync(item.MapTo<Picture>());
                }
            }

            if (input.ProductAttributes != null && input.ProductAttributes.Count > 0)
            {
                foreach (var item in input.ProductAttributes)
                {
                    item.ProductId = entity.Id;
                    await _attributeRepository.InsertAsync(item.MapTo<ProductAttribute>());
                }
            }

            return entity.MapTo<ProductEditDto>();
        }

        /// <summary>
        /// 编辑Product
        /// </summary>
        [AbpAuthorize(ProductPermissions.Edit)]
        protected virtual async Task Update(CreateOrUpdateProductInput input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Product.Id.Value);
            input.Product.MapTo(entity);
            await _entityManager.UpdateAsync(entity);

            if (input.Pictures != null && input.Pictures.Count > 0)
            {
                await _pictureRepository.DeleteAsync(m => m.ProductId == entity.Id);
                foreach (var item in input.Pictures)
                {
                    item.ProductId = entity.Id;
                    await _pictureRepository.InsertAsync(item.MapTo<Picture>());
                }
            }

            if (input.ProductAttributes != null && input.ProductAttributes.Count > 0)
            {
                await _attributeRepository.DeleteAsync(m=>m.ProductId==entity.Id);
                foreach (var item in input.ProductAttributes)
                {
                    item.ProductId = entity.Id;
                    await _attributeRepository.InsertAsync(item.MapTo<ProductAttribute>());
                }
            }

            // ObjectMapper.Map(input, entity);
        }



        /// <summary>
        /// 删除Product信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ProductPermissions.Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Product的方法
        /// </summary>
        [AbpAuthorize(ProductPermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        /// <summary>
        /// 导出Product为excel表,等待开发。
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetToExcel()
        //{
        //	var users = await UserManager.Users.ToListAsync();
        //	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //	await FillRoleNames(userListDtos);
        //	return _userListExcelExporter.ExportToFile(userListDtos);
        //}

    }
}


