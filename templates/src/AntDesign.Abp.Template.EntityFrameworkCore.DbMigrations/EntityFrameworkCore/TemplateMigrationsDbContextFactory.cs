using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AntDesign.Abp.Template.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TemplateMigrationsDbContextFactory : IDesignTimeDbContextFactory<TemplateMigrationsDbContext>
    {
        public TemplateMigrationsDbContext CreateDbContext(string[] args)
        {
            TemplateEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TemplateMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new TemplateMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AntDesign.Abp.Template.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
