using System;
using System.Collections.Generic;
using System.Text;
using AntDesign.Abp.Pro.Localization;
using Volo.Abp.Application.Services;

namespace AntDesign.Abp.Pro
{
    /* Inherit your application services from this class.
     */
    public abstract class ProAppService : ApplicationService
    {
        protected ProAppService()
        {
            LocalizationResource = typeof(ProResource);
        }
    }
}
