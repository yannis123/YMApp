using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YMApp.Categorys.Dtos;

namespace YMApp.Categorys
{
    public interface ICategoryApplicationService : IApplicationService
    {

        Task<PagedResultDto<CategoryListDto>> GetPaged(GetCategorysInput input);



        Task<CategoryListDto> GetById(EntityDto<long> input);



        Task<GetCategoryForEditOutput> GetForEdit(NullableIdDto<long> input);



        Task CreateOrUpdate(CreateOrUpdateCategoryInput input);


       
        Task Delete(EntityDto<long> input);


       
        Task BatchDelete(List<long> input);

        Task<List<CategoryListDto>> GetListByParentId(long pId);

        Task<List<CategoryListDto>> GetListByType(int type);

        Task<TreeTableeDto> GetTreeTableByType();

        //Task<FileDto> GetToExcel();
    }
}
