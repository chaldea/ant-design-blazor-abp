using AntDesign.Abp.Template.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AntDesign.Abp.Template
{
    [DependsOn(
        typeof(TemplateEntityFrameworkCoreTestModule)
        )]
    public class TemplateDomainTestModule : AbpModule
    {

    }
}