using AntDesign.Abp.Template.Localization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components;

namespace AntDesign.Abp.Template.Blazor
{
    public abstract class TemplateComponentBase : AbpComponentBase
    {
        internal const string BodyPropertyName = "Body";

        [Parameter]
        public RenderFragment? Body { get; set; }

        protected TemplateComponentBase()
        {
            LocalizationResource = typeof(TemplateResource);
        }
    }
}
