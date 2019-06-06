using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using YMApp.Authorization.Roles;
using YMApp.Authorization.Users;
using YMApp.MultiTenancy;
using YMApp.Categorys;
using YMApp.Trips;
using YMApp.ECommerce.Pictures;
using YMApp.ECommerce.Products;
using YMApp.ECommerce.ProductFields;
using YMApp.ECommerce.ProductAttributes;
using YMApp.ECommerce.Articles;

namespace YMApp.EntityFrameworkCore
{
    public class YMAppDbContext : AbpZeroDbContext<Tenant, Role, User, YMAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductField> ProductFields { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Article> Articles { get; set; }

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
