using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AntDesign.Abp.Template.Data
{
    /* This is used if database provider does't define
     * ITemplateDbSchemaMigrator implementation.
     */
    public class NullTemplateDbSchemaMigrator : ITemplateDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}