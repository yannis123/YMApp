using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Authorization;

namespace YMApp.Roles.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
        public string ParentName { get; set; }
    }
}
