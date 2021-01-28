using System.Collections.Generic;
using AntDesign.Abp.Template.Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Abp.Template.Blazor.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}