using System.Threading.Tasks;
using AntDesign.Abp.Template.Blazor.Models;
using AntDesign.Abp.Template.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Template.Blazor.Pages.Account.Settings
{
    public partial class BaseView
    {
        private CurrentUser _currentUser = new CurrentUser();

        [Inject] protected IUserService UserService { get; set; }

        private void HandleFinish()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _currentUser = await UserService.GetCurrentUserAsync();
        }
    }
}