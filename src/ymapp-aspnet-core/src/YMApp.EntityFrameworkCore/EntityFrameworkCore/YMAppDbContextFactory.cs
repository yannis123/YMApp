using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using YMApp.Configuration;
using YMApp.Web;

namespace YMApp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class YMAppDbContextFactory : IDesignTimeDbContextFactory<YMAppDbContext>
    {
        public YMAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<YMAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            YMAppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(YMAppConsts.ConnectionStringName));

            return new YMAppDbContext(builder.Options);
        }
    }
}
