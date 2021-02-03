using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign.Pro.Layout;
using AntDesign.Abp.Template.Blazor.Models;
using AntDesign.Abp.Template.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Volo.Abp.Localization;
using Microsoft.JSInterop;

namespace AntDesign.Abp.Template.Blazor.Components
{
    public partial class RightContent
    {
        private CurrentUser _currentUser = new CurrentUser();
        private NoticeIconData[] _notifications = { };
        private NoticeIconData[] _messages = { };
        private NoticeIconData[] _events = { };
        private int _count = 0;
        private string[] _locales = { };
        private Dictionary<string, string> _languageLabels = new();
        private Dictionary<string, string> _languageIcons = new();

        private List<AutoCompleteDataItem<string>> DefaultOptions { get; set; } = new List<AutoCompleteDataItem<string>>
        {
            new AutoCompleteDataItem<string>
            {
                Label = "umi ui",
                Value = "umi ui"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Table",
                Value = "Pro Table"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Layout",
                Value = "Pro Layout"
            }
        };

        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected IUserService UserService { get; set; }
        [Inject] protected IProjectService ProjectService { get; set; }
        [Inject] protected MessageService MessageService { get; set; }
        [Inject] protected SignOutSessionStateManager SignOutManager { get; set; }
        [Inject] protected ILanguageProvider LanguageProvider { get; set; }
        [Inject] protected IJSRuntime JsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SetClassMap();
            _currentUser = await UserService.GetCurrentUserAsync();
            var notices = await ProjectService.GetNoticesAsync();
            _notifications = notices.Where(x => x.Type == "notification").Cast<NoticeIconData>().ToArray();
            _messages = notices.Where(x => x.Type == "message").Cast<NoticeIconData>().ToArray();
            _events = notices.Where(x => x.Type == "event").Cast<NoticeIconData>().ToArray();
            _count = notices.Length;

            var langs = await LanguageProvider.GetLanguagesAsync();
            _locales = langs.Select(x => x.CultureName).ToArray();
            _languageLabels = langs.ToDictionary(x => x.CultureName, y => y.DisplayName);
            _languageIcons = langs.ToDictionary(x => x.CultureName, y => y.FlagIcon);
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("right");
        }

        public async Task HandleSelectUser(MenuItem item)
        {
            switch (item.Key)
            {
                case "center":
                    NavigationManager.NavigateTo("/account/center");
                    break;
                case "setting":
                    NavigationManager.NavigateTo("/account/settings");
                    break;
                case "logout":
                    await SignOutManager.SetSignOutState();
                    NavigationManager.NavigateTo($"authentication/logout?returnUrl={Uri.EscapeDataString(NavigationManager.Uri)}");
                    break;
            }
        }

        public async Task HandleSelectLang(MenuItem item)
        {
            await JsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                "Abp.SelectedLanguage",
                item.Key
            );

            await JsRuntime.InvokeVoidAsync("location.reload");
        }

        public async Task HandleClear(string key)
        {
            switch (key)
            {
                case "notification":
                    _notifications = new NoticeIconData[] { };
                    break;
                case "message":
                    _messages = new NoticeIconData[] { };
                    break;
                case "event":
                    _events = new NoticeIconData[] { };
                    break;
            }
            await MessageService.Success($"清空了{key}");
        }

        public async Task HandleViewMore(string key)
        {
            await MessageService.Info("Click on view more");
        }
    }
}