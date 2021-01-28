using System.Threading.Tasks;

namespace AntDesign.Abp.Template.Data
{
    public interface ITemplateDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
