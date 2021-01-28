using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AntDesign.Abp.Template
{
    [Dependency(ReplaceServices = true)]
    public class TemplateBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Template";
    }
}
