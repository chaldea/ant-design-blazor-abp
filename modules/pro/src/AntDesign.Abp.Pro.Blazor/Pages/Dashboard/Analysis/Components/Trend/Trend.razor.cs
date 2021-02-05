using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Pro.Blazor.Pages.Dashboard.Analysis
{
    public partial class Trend
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Flag { get; set; }
    }
}