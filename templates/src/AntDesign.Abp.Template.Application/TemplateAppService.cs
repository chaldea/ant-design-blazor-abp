using System;
using System.Collections.Generic;
using System.Text;
using AntDesign.Abp.Template.Localization;
using Volo.Abp.Application.Services;

namespace AntDesign.Abp.Template
{
    /* Inherit your application services from this class.
     */
    public abstract class TemplateAppService : ApplicationService
    {
        protected TemplateAppService()
        {
            LocalizationResource = typeof(TemplateResource);
        }
    }
}
