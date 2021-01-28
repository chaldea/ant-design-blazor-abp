using AntDesign.Abp.Template.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AntDesign.Abp.Template.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TemplateController : AbpController
    {
        protected TemplateController()
        {
            LocalizationResource = typeof(TemplateResource);
        }
    }
}