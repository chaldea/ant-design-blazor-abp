using Volo.Abp.Modularity;

namespace AntDesign.Abp.Template
{
    [DependsOn(
        typeof(TemplateApplicationModule),
        typeof(TemplateDomainTestModule)
        )]
    public class TemplateApplicationTestModule : AbpModule
    {

    }
}