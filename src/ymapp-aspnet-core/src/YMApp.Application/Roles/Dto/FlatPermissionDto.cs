using Abp.AutoMapper;

namespace YMApp.Roles.Dto
{
    public class FlatPermissionDto
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }
        public string ParentName { get; set; }
    }
}