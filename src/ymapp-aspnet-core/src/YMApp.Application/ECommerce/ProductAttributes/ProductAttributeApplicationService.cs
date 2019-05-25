
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using YMApp.ECommerce.ProductAttributes;
using YMApp.ECommerce.ProductAttributes.Dtos;
using YMApp.ECommerce.ProductAttributes.DomainService;



namespace YMApp.ECommerce.ProductAttributes
{
    /// <summary>
    /// ProductAttribute应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ProductAttributeAppService : YMAppAppServiceBase, IProductAttributeAppService
    {
        private readonly IRepository<ProductAttribute, long> _entityRepository;

        private readonly IProductAttributeManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProductAttributeAppService(
        IRepository<ProductAttribute, long> entityRepository
        , IProductAttributeManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取ProductAttribute的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<ProductAttributeListDto>> GetPaged(GetProductAttributesInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<ProductAttributeListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<ProductAttributeListDto>>();

            return new PagedResultDto<ProductAttributeListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取ProductAttributeListDto信息
        /// </summary>

        public async Task<ProductAttributeListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<ProductAttributeListDto>();
        }

        /// <summary>
        /// 获取编辑 ProductAttribute
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetProductAttributeForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetProductAttributeForEditOutput();
            ProductAttributeEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<ProductAttributeEditDto>();

                //productAttributeEditDto = ObjectMapper.Map<List<productAttributeEditDto>>(entity);
            }
            else
            {
                editDto = new ProductAttributeEditDto();
            }

            output.ProductAttribute = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改ProductAttribute的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateProductAttributeInput input)
        {

            if (input.ProductAttribute.Id.HasValue)
            {
                await Update(input.ProductAttribute);
            }
            else
            {
                await Create(input.ProductAttribute);
            }
        }


        /// <summary>
        /// 新增ProductAttribute
        /// </summary>

        protected virtual async Task<ProductAttributeEditDto> Create(ProductAttributeEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <ProductAttribute>(input);
            var entity = input.MapTo<ProductAttribute>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<ProductAttributeEditDto>();
        }

        /// <summary>
        /// 编辑ProductAttribute
        /// </summary>

        protected virtual async Task Update(ProductAttributeEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除ProductAttribute信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除ProductAttribute的方法
        /// </summary>

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<List<ProductAttributeListDto>> GetListByProductId(NullableIdDto<long> input)
        {
            List<ProductAttribute> entityList = new List<ProductAttribute>();
            if (input.Id.HasValue)
            {
                entityList = await _entityRepository.GetAllListAsync(m => m.ProductId == input.Id);
            }
            return entityList?.MapTo<List<ProductAttributeListDto>>();
        }

        /// <summary>
        /// 导出ProductAttribute为excel表,等待开发。
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


