using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Template.Blazor.Pages.Dashboard.Monitor
{
    public partial class TagCloud
    {
        [Parameter]
        public object[] Data { get; set; }

        [Parameter]
        public int? Height { get; set; }
    }
}