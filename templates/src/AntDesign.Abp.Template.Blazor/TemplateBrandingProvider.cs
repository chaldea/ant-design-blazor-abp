using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AntDesign.Abp.Template.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class TemplateBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Template";
    }
}
