using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace YMApp.EntityFrameworkCore
{
    public static class YMAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<YMAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<YMAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
