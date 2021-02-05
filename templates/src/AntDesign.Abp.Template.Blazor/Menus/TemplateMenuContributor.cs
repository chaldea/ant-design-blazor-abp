using System;
using System.Threading.Tasks;
using AntDesign.Abp.Template.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace AntDesign.Abp.Template.Blazor.Menus
{
    public class TemplateMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public TemplateMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<TemplateResource>();
            context.Menu.TryRemoveMenuItem(DefaultMenuNames.Application.Main.Administration);
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
            
            // todo: separate into different modules.
            context.Menu.Items.Add(
                new ApplicationMenuItem(
                        TemplateMenus.Dashboard,
                        l["Menu:Dashboard"],
                        "/dashboard",
                        "dashboard")
                    .AddItem(
                        new ApplicationMenuItem(
                            TemplateMenus.DashboardAnalysis,
                            l["Menu:DashboardAnalysis"],
                            "/"))
                    .AddItem(
                        new ApplicationMenuItem(
                            TemplateMenus.DashboardMonitor,
                            l["Menu:DashboardMonitor"],
                            "/dashboard/monitor"))
                    .AddItem(
                        new ApplicationMenuItem(
                            TemplateMenus.DashboardWorkplace,
                            l["Menu:DashboardWorkplace"],
                            "/dashboard/workplace"))
            );

            if (!currentUser.IsAuthenticated) return Task.CompletedTask;

            context.Menu.Items.Add(
                new ApplicationMenuItem(
                        TemplateMenus.Form,
                        l["Menu:Form"],
                        "/form",
                        "form")
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.FormBasic,
                        l["Menu:FormBasic"],
                        "/form/basic-form"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.FormStep,
                        l["Menu:FormStep"],
                        "/form/step-form"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.FormAdvanced,
                        l["Menu:FormAdvanced"],
                        "/form/advanced-form"))
            );

            context.Menu.Items.Add(
                new ApplicationMenuItem(
                        TemplateMenus.List,
                        l["Menu:List"],
                        "/list",
                        "table")
                    .AddItem(new ApplicationMenuItem(
                            TemplateMenus.ListSearch,
                            l["Menu:ListSearch"],
                            "/list/search")
                        .AddItem(new ApplicationMenuItem(
                            TemplateMenus.ListSearchArticles,
                            l["Menu:ListSearchArticles"],
                            "/list/search/articles"))
                        .AddItem(new ApplicationMenuItem(
                            TemplateMenus.ListSearchProjects,
                            l["Menu:ListSearchProjects"],
                            "/list/search/projects"))
                        .AddItem(new ApplicationMenuItem(
                            TemplateMenus.ListSearchApplications,
                            l["Menu:ListSearchApplications"],
                            "/list/search/applications")))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.ListTable,
                        l["Menu:ListTable"],
                        "/list/table-list"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.ListBasic,
                        l["Menu:ListBasic"],
                        "/list/basic-list"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.ListCard,
                        l["Menu:ListCard"],
                        "/list/card-list"))
            );

            context.Menu.Items.Add(
                new ApplicationMenuItem(
                        TemplateMenus.Profile,
                        l["Menu:Profile"],
                        "/profile",
                        "profile")
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.ProfileBasic,
                        l["Menu:ProfileBasic"],
                        "/profile/basic"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.ProfileAdvanced,
                        l["Menu:ProfileAdvanced"],
                        "/profile/advanced"))
            );

            context.Menu.Items.Add(
                new ApplicationMenuItem(
                        TemplateMenus.Result,
                        l["Menu:Result"],
                        "/result",
                        "check-circle")
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.ResultSuccess,
                        l["Menu:ResultSuccess"],
                        "/result/success"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.ResultFail,
                        l["Menu:ResultFail"],
                        "/result/fail"))
            );

            context.Menu.Items.Add(
                new ApplicationMenuItem(
                        TemplateMenus.Exception,
                        l["Menu:Exception"],
                        "/exception",
                        "exception")
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.Exception403,
                        l["Menu:Exception403"],
                        "/exception/403"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.Exception404,
                        l["Menu:Exception404"],
                        "/exception/404"))
                    .AddItem(new ApplicationMenuItem(
                        TemplateMenus.Exception500,
                        l["Menu:Exception500"],
                        "/exception/500"))
            );

            context.Menu.Items.Add(new ApplicationMenuItem(
                    TemplateMenus.Account,
                    l["Menu:Account"],
                    "/account", "user")
                .AddItem(new ApplicationMenuItem(
                    TemplateMenus.AccountCenter,
                    l["Menu:AccountCenter"],
                    "/account/center"))
                .AddItem(new ApplicationMenuItem(
                    TemplateMenus.AccountSettings,
                    l["Menu:AccountSettings"],
                    "/account/settings"))
            );

            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var accountStringLocalizer = context.GetLocalizer<AccountResource>();
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            if (currentUser.IsAuthenticated)
            {
                context.Menu.AddItem(new ApplicationMenuItem(
                    "Account.Manage",
                    accountStringLocalizer["ManageYourProfile"],
                    $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage",
                    "fa fa-cog",
                    1000,
                    null,
                    "_blank"));
            }

            return Task.CompletedTask;
        }
    }
}