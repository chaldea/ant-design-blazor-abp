using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AntDesign.Abp.Template.Data;
using Volo.Abp.DependencyInjection;

namespace AntDesign.Abp.Template.EntityFrameworkCore
{
    public class EntityFrameworkCoreTemplateDbSchemaMigrator
        : ITemplateDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTemplateDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TemplateMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TemplateMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}