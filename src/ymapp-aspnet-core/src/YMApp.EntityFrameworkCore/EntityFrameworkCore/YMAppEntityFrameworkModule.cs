using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YMApp.EntityFrameworkCore.Seed;

namespace YMApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(YMAppCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class YMAppEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<YMAppDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        YMAppDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        YMAppDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
{
    IocManager.RegisterAssemblyByConvention(typeof(YMAppEntityFrameworkModule).GetAssembly());
}

public override void PostInitialize()
{
    if (!SkipDbSeed)
    {
        SeedHelper.SeedHostDb(IocManager);
    }
}
    }
}
