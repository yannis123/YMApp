
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


using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.Pictures.Dtos;
using YMApp.ECommerce.Pictures.DomainService;
using YMApp.ECommerce.Pictures.Authorization;


namespace YMApp.ECommerce.Pictures
{
    /// <summary>
    /// Picture应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class PictureAppService : YMAppAppServiceBase, IPictureAppService
    {
        private readonly IRepository<Picture, long> _entityRepository;

        private readonly IPictureManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public PictureAppService(
        IRepository<Picture, long> entityRepository
        , IPictureManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取Picture的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(PicturePermissions.Query)]
        public async Task<PagedResultDto<PictureListDto>> GetPaged(GetPicturesInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<PictureListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<PictureListDto>>();

            return new PagedResultDto<PictureListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取PictureListDto信息
        /// </summary>
        [AbpAuthorize(PicturePermissions.Query)]
        public async Task<PictureListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<PictureListDto>();
        }

        /// <summary>
        /// 获取编辑 Picture
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PicturePermissions.Create, PicturePermissions.Edit)]
        public async Task<GetPictureForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetPictureForEditOutput();
            PictureEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<PictureEditDto>();

                //pictureEditDto = ObjectMapper.Map<List<pictureEditDto>>(entity);
            }
            else
            {
                editDto = new PictureEditDto();
            }

            output.Picture = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Picture的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PicturePermissions.Create, PicturePermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdatePictureInput input)
        {

            if (input.Picture.Id.HasValue)
            {
                await Update(input.Picture);
            }
            else
            {
                await Create(input.Picture);
            }
        }


        /// <summary>
        /// 新增Picture
        /// </summary>
        [AbpAuthorize(PicturePermissions.Create)]
        protected virtual async Task<PictureEditDto> Create(PictureEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Picture>(input);
            var entity = input.MapTo<Picture>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<PictureEditDto>();
        }

        /// <summary>
        /// 编辑Picture
        /// </summary>
        [AbpAuthorize(PicturePermissions.Edit)]
        protected virtual async Task Update(PictureEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Picture信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PicturePermissions.Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Picture的方法
        /// </summary>
        [AbpAuthorize(PicturePermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task<List<PictureListDto>> GetListByProductId(NullableIdDto<long> input)
        {
            if (input.Id.HasValue)
            {
                var entityList = await _entityRepository.GetAllListAsync(m => m.ProductId == input.Id);
                return entityList.MapTo<List<PictureListDto>>();
            }
            return new List<PictureListDto>();
        }

        /// <summary>
        /// 导出Picture为excel表,等待开发。
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


