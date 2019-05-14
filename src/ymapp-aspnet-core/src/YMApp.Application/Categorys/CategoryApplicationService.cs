using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using YMApp.Categorys.Dtos;
using Abp.Linq.Extensions;


namespace YMApp.Categorys
{
    public class CategoryApplicationService : YMAppAppServiceBase, ICategoryApplicationService
    {
        private readonly IRepository<Category, long> _entityRepository;
        public CategoryApplicationService(IRepository<Category, long> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task BatchDelete(List<long> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        public async Task CreateOrUpdate(CreateOrUpdateCategoryInput input)
        {
            if (input.Category.Id.HasValue)
            {
                await Update(input.Category);
            }
            else
            {
                await Create(input.Category);
            }
        }
        protected virtual async Task<CategoryEditDto> Create(CategoryEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Book>(input);
            var entity = input.MapTo<Category>();

            var entityId = await _entityRepository.InsertAndGetIdAsync(entity);

            return entity.MapTo<CategoryEditDto>();
        }

        protected virtual async Task Update(CategoryEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            //ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);

        }

        public async Task Delete(EntityDto<long> input)
        {
            await _entityRepository.DeleteAsync(input.Id);
        }

        public async Task<CategoryListDto> GetById(EntityDto<long> input)
        {

            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<CategoryListDto>();
        }

        public async Task<GetCategoryForEditOutput> GetForEdit(NullableIdDto<long> input)
        {
            var output = new GetCategoryForEditOutput();
            CategoryEditDto editDto;
            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<CategoryEditDto>();
            }
            else
            {
                editDto = new CategoryEditDto();
            }
            output.Category = editDto;
            return output;
        }

        public async Task<PagedResultDto<CategoryListDto>> GetPaged(GetCategorysInput input)
        {
            var query = _entityRepository
                .GetAll()
                .AsNoTracking()
                // TODO:根据传入的参数添加过滤条件
                .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), o => o.Name.Contains(input.FilterText));

            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<BookListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<CategoryListDto>>();

            return new PagedResultDto<CategoryListDto>(count, entityListDtos);
        }
    }
}
