using System.Threading.Tasks;
using AntDesign.Abp.Pro.Blazor.Models;
using AntDesign.Abp.Pro.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Pro.Blazor.Pages.Dashboard.Workplace
{
    public partial class Index
    {
        private readonly EditableLink[] _links =
        {
            new EditableLink {Title = "操作一", Href = ""},
            new EditableLink {Title = "操作二", Href = ""},
            new EditableLink {Title = "操作三", Href = ""},
            new EditableLink {Title = "操作四", Href = ""},
            new EditableLink {Title = "操作五", Href = ""},
            new EditableLink {Title = "操作六", Href = ""}
        };

        private ActivitiesType[] _activities = { };
        private NoticeType[] _projectNotice = { };

        [Inject] public IProjectService ProjectService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _projectNotice = await ProjectService.GetProjectNoticeAsync();
            _activities = await ProjectService.GetActivitiesAsync();
        }
    }
}