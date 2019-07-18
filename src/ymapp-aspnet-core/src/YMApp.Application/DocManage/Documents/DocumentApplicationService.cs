
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


using YMApp.DocManage.Documents;
using YMApp.DocManage.Documents.Dtos;
using YMApp.DocManage.Documents.DomainService;
using YMApp.DocManage.Documents.Authorization;
using YMApp.ECommerce.Documents.Dtos;

namespace YMApp.DocManage.Documents
{
    /// <summary>
    /// Document应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class DocumentAppService : YMAppAppServiceBase, IDocumentAppService
    {
        private readonly IRepository<Document, long> _entityRepository;

        private readonly IDocumentManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public DocumentAppService(
        IRepository<Document, long> entityRepository
        , IDocumentManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取Document的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(DocumentPermissions.Query)]
        public async Task<PagedResultDto<DocumentListDto>> GetPaged(GetDocumentsInput input)
        {
            var query = _entityRepository.GetAll().AsNoTracking()
               .WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name))
               .WhereIf(input.State.HasValue, m => m.State == input.State)
               .WhereIf(input.CategoryId.HasValue, m => m.CategoryId == input.CategoryId)
               .WhereIf(input.Start.HasValue, m => m.CreationTime > input.Start)
               .WhereIf(input.End.HasValue, m => m.CreationTime < input.End)
               .Include(m => m.Category);
            // TODO:根据传入的参数添加过滤条件

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<DocumentListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<DocumentListDto>>();

            return new PagedResultDto<DocumentListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取DocumentListDto信息
        /// </summary>
        [AbpAuthorize(DocumentPermissions.Query)]
        public async Task<DocumentListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<DocumentListDto>();
        }

        /// <summary>
        /// 获取编辑 Document
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(DocumentPermissions.Create, DocumentPermissions.Edit)]
        public async Task<GetDocumentForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetDocumentForEditOutput();
            DocumentEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<DocumentEditDto>();

                //documentEditDto = ObjectMapper.Map<List<documentEditDto>>(entity);
            }
            else
            {
                editDto = new DocumentEditDto();
            }

            output.Document = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Document的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(DocumentPermissions.Create, DocumentPermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateDocumentInput input)
        {

            if (input.Document.Id.HasValue)
            {
                await Update(input.Document);
            }
            else
            {
                await Create(input.Document);
            }
        }


        /// <summary>
        /// 新增Document
        /// </summary>
        [AbpAuthorize(DocumentPermissions.Create)]
        protected virtual async Task<DocumentEditDto> Create(DocumentEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Document>(input);
            var entity = input.MapTo<Document>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<DocumentEditDto>();
        }

        /// <summary>
        /// 编辑Document
        /// </summary>
        [AbpAuthorize(DocumentPermissions.Edit)]
        protected virtual async Task Update(DocumentEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Document信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(DocumentPermissions.Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Document的方法
        /// </summary>
        [AbpAuthorize(DocumentPermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        /// <summary>
        /// 导出Document为excel表,等待开发。
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetToExcel()
        //{
        //	var users = await UserManager.Users.ToListAsync();
        //	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //	await FillRoleNames(userListDtos);
        //	return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        public async Task ChangeAuditState(ChangetDocumentAuditStateDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id.Value);
            entity.State = input.State;
            await _entityRepository.UpdateAsync(entity);
        }
    }
}


