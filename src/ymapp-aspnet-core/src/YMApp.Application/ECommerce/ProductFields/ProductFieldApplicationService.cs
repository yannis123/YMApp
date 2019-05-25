
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


using YMApp.ECommerce.ProductFields;
using YMApp.ECommerce.ProductFields.Dtos;
using YMApp.ECommerce.ProductFields.DomainService;



namespace YMApp.ECommerce.ProductFields
{
    /// <summary>
    /// ProductField应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ProductFieldAppService : YMAppAppServiceBase, IProductFieldAppService
    {
        private readonly IRepository<ProductField, long> _entityRepository;

        private readonly IProductFieldManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProductFieldAppService(
        IRepository<ProductField, long> entityRepository
        , IProductFieldManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取ProductField的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<PagedResultDto<ProductFieldListDto>> GetPaged(GetProductFieldsInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<ProductFieldListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<ProductFieldListDto>>();

            return new PagedResultDto<ProductFieldListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取ProductFieldListDto信息
        /// </summary>

        public async Task<ProductFieldListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<ProductFieldListDto>();
        }

        /// <summary>
        /// 获取编辑 ProductField
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task<GetProductFieldForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetProductFieldForEditOutput();
            ProductFieldEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<ProductFieldEditDto>();

                //productFieldEditDto = ObjectMapper.Map<List<productFieldEditDto>>(entity);
            }
            else
            {
                editDto = new ProductFieldEditDto();
            }

            output.ProductField = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改ProductField的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task CreateOrUpdate(CreateOrUpdateProductFieldInput input)
        {

            if (input.ProductField.Id.HasValue)
            {
                await Update(input.ProductField);
            }
            else
            {
                await Create(input.ProductField);
            }
        }


        /// <summary>
        /// 新增ProductField
        /// </summary>

        protected virtual async Task<ProductFieldEditDto> Create(ProductFieldEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <ProductField>(input);
            var entity = input.MapTo<ProductField>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<ProductFieldEditDto>();
        }

        /// <summary>
        /// 编辑ProductField
        /// </summary>

        protected virtual async Task Update(ProductFieldEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除ProductField信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除ProductField的方法
        /// </summary>

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<List<ProductFieldListDto>> GetProductFieldByProductType(long productType)
        {
            var list = await _entityRepository.GetAllListAsync(m => m.ProductType == productType);
            return list.MapTo<List<ProductFieldListDto>>();
        }


        /// <summary>
        /// 导出ProductField为excel表,等待开发。
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


