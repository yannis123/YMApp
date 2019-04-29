using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using YMApp.Authorization.Roles;
using YMApp.Authorization.Users;
using YMApp.MultiTenancy;
using YMApp.Categorys;

namespace YMApp.EntityFrameworkCore
{
    public class YMAppDbContext : AbpZeroDbContext<Tenant, Role, User, YMAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Category> Categorys { get; set; }


        public YMAppDbContext(DbContextOptions<YMAppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //�Զ����ؼ��ز�ִ�м̳���EntityMappingConfiguration����ﵽͳһ��ʵ�����ͽ������õ�Ŀ��
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
