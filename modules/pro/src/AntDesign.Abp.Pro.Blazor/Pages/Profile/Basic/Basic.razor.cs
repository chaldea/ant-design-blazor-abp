using System.Threading.Tasks;
using AntDesign.Abp.Pro.Blazor.Models;
using AntDesign.Abp.Pro.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Pro.Blazor.Pages.Profile
{
    public partial class Basic
    {
        private BasicProfileDataType _data = new BasicProfileDataType();

        [Inject] protected IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _data = await ProfileService.GetBasicAsync();
        }
    }
}