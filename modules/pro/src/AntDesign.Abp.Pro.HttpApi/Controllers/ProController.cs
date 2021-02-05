using AntDesign.Abp.Pro.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AntDesign.Abp.Pro.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ProController : AbpController
    {
        protected ProController()
        {
            LocalizationResource = typeof(ProResource);
        }
    }
}