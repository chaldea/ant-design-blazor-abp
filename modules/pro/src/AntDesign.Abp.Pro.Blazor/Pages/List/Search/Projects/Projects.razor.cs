using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign.Abp.Pro.Blazor.Models;
using AntDesign.Abp.Pro.Blazor.Services;
using Microsoft.AspNetCore.Components;
using AntDesign;

namespace AntDesign.Abp.Pro.Blazor.Pages.List
{
    public partial class Projects
    {
        private readonly ListGridType _listGridType = new ListGridType
        {
            Gutter = 24,
            Column = 4
        };

        private readonly ListFormModel _model = new ListFormModel();

        private IList<ListItemDataType> _fakeList = new List<ListItemDataType>();

        [Inject] public IProjectService ProjectService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _fakeList = await ProjectService.GetFakeListAsync(8);
        }
    }
}