
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


using YMApp.ECommerce.Articles;
using YMApp.ECommerce.Articles.Dtos;
using YMApp.ECommerce.Articles.DomainService;
using YMApp.ECommerce.Articles.Authorization;


namespace YMApp.ECommerce.Articles
{
    /// <summary>
    /// Article应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ArticleAppService : YMAppAppServiceBase, IArticleAppService
    {
        private readonly IRepository<Article, long> _entityRepository;

        private readonly IArticleManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ArticleAppService(
        IRepository<Article, long> entityRepository
        , IArticleManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取Article的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(ArticlePermissions.Query)]
        public async Task<PagedResultDto<ArticleListDto>> GetPaged(GetArticlesInput input)
        {

            var query = _entityRepository.GetAll().AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(input.Title), m => m.Title.Contains(input.Title))
                .WhereIf(input.State.HasValue, m => m.State == input.State)
                .WhereIf(input.CategoryId.HasValue, m => m.CategoryId == input.CategoryId)
                .WhereIf(input.Start.HasValue, m => m.CreationTime > input.Start)
                .WhereIf(input.End.HasValue, m => m.CreationTime < input.End);
            // TODO:根据传入的参数添加过滤条件


            var count = await query.CountAsync();

            var entityList = await query
                    .Include(m => m.Category)
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<ArticleListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<ArticleListDto>>();

            return new PagedResultDto<ArticleListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取ArticleListDto信息
        /// </summary>
        [AbpAuthorize(ArticlePermissions.Query)]
        public async Task<ArticleListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<ArticleListDto>();
        }

        /// <summary>
        /// 获取编辑 Article
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ArticlePermissions.Create, ArticlePermissions.Edit)]
        public async Task<GetArticleForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetArticleForEditOutput();
            ArticleEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<ArticleEditDto>();

                //articleEditDto = ObjectMapper.Map<List<articleEditDto>>(entity);
            }
            else
            {
                editDto = new ArticleEditDto();
            }

            output.Article = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Article的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ArticlePermissions.Create, ArticlePermissions.Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateArticleInput input)
        {

            if (input.Article.Id.HasValue)
            {
                await Update(input.Article);
            }
            else
            {
                await Create(input.Article);
            }
        }


        /// <summary>
        /// 新增Article
        /// </summary>
        [AbpAuthorize(ArticlePermissions.Create)]
        protected virtual async Task<ArticleEditDto> Create(ArticleEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Article>(input);
            var entity = input.MapTo<Article>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<ArticleEditDto>();
        }

        /// <summary>
        /// 编辑Article
        /// </summary>
        [AbpAuthorize(ArticlePermissions.Edit)]
        protected virtual async Task Update(ArticleEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除Article信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(ArticlePermissions.Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Article的方法
        /// </summary>
        [AbpAuthorize(ArticlePermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task ChangeAuditState(ChangetArticleAuditStateDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id.Value);
            entity.State = input.State;
            await _entityRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 导出Article为excel表,等待开发。
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


