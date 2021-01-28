using AntDesign.Abp.Template.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AntDesign.Abp.Template.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TemplateEntityFrameworkCoreDbMigrationsModule),
        typeof(TemplateApplicationContractsModule)
        )]
    public class TemplateDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
