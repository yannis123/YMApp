using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;

namespace YMApp.EntityFrameworkCore
{
    public static class YMAppDbContextConfigurer
    {
        public static readonly ILoggerFactory DbCommandConsoleLoggerFactory
   = new LoggerFactory(new[] {
      new ConsoleLoggerProvider ((category, level) =>
        category == DbLoggerCategory.Database.Command.Name &&
        level == LogLevel.Information, true)
     });
        public static void Configure(DbContextOptionsBuilder<YMAppDbContext> builder, string connectionString)
        {
            DbCommandConsoleLoggerFactory.AddLog4Net();
            builder.UseLoggerFactory(DbCommandConsoleLoggerFactory).EnableSensitiveDataLogging().UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<YMAppDbContext> builder, DbConnection connection)
        {
            DbCommandConsoleLoggerFactory.AddLog4Net();
            builder.UseLoggerFactory(DbCommandConsoleLoggerFactory).EnableSensitiveDataLogging().UseSqlServer(connection);
        }
    }
}
