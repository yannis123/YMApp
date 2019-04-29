using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using YMApp.Authorization.Roles;
using YMApp.Authorization.Users;
using YMApp.MultiTenancy;

namespace YMApp.EntityFrameworkCore
{
    public class YMAppDbContext : AbpZeroDbContext<Tenant, Role, User, YMAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public YMAppDbContext(DbContextOptions<YMAppDbContext> options)
            : base(options)
        {
        }
    }
}
