using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Template.Blazor.Pages.Dashboard.Analysis
{
    public partial class Field
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Value { get; set; }
    }
}