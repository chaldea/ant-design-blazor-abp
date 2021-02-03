using System.Collections.Generic;
using AntDesign.Abp.Template.Blazor.Models;
using Microsoft.AspNetCore.Components;
using AntDesign;

namespace AntDesign.Abp.Template.Blazor.Pages.Account.Center
{
    public partial class Applications
    {
        private readonly ListGridType _listGridType = new ListGridType
        {
            Gutter = 24,
            Column = 4
        };

        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}