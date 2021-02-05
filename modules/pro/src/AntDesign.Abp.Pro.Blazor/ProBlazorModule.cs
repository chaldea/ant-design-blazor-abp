using Volo.Abp.Modularity;

namespace AntDesign.Abp.Pro.Blazor
{
    [DependsOn(
        typeof(ProHttpApiClientModule)
    )]
    public class ProBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }

        private void ConfigureMenu(ServiceConfigurationContext context)
        {

        }
    }
}