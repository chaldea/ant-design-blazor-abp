using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign.Abp.Template.Blazor.Models;
using AntDesign.Abp.Template.Blazor.Services;
using Microsoft.AspNetCore.Components;
using AntDesign;

namespace AntDesign.Abp.Template.Blazor.Pages.List
{
    public partial class BasicList
    {
        private readonly BasicListFormModel _model = new BasicListFormModel();

        private readonly IDictionary<string, ProgressStatus> _pStatus = new Dictionary<string, ProgressStatus>
        {
            {"active", ProgressStatus.Active},
            {"exception", ProgressStatus.Exception},
            {"normal", ProgressStatus.Normal},
            {"success", ProgressStatus.Success}
        };

        private ListItemDataType[] _data = { };

        [Inject] protected IProjectService ProjectService { get; set; }

        private void ShowModal()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _data = await ProjectService.GetFakeListAsync(5);
        }
    }
}