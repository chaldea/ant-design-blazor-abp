using System;
using System.Net.Http;
using AntDesign.Abp.Template.Blazor.Menus;
using AntDesign.Abp.Template.Blazor.Services;
using AntDesign.Pro.Layout;
using IdentityModel;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.AutoMapper;
using Volo.Abp.TenantManagement.Blazor;

namespace AntDesign.Abp.Template.Blazor
{
    [DependsOn(
        typeof(AbpAutofacWebAssemblyModule),
        typeof(TemplateHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyBasicThemeModule),
        typeof(AbpIdentityBlazorModule),
        typeof(AbpTenantManagementBlazorModule)
    )]
    public class TemplateBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
            var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

            ConfigureAuthentication(builder);
            ConfigureHttpClient(context, environment);
            ConfigureBlazorise(context);
            ConfigureRouter(context);
            ConfigureUI(builder);
            ConfigureMenu(context);
            ConfigureAutoMapper(context);
        }

        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(TemplateBlazorModule).Assembly;
            });
        }

        private void ConfigureMenu(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new TemplateMenuContributor(context.Services.GetConfiguration()));
            });
        }

        private void ConfigureBlazorise(ServiceConfigurationContext context)
        {
            context.Services.AddAntDesign();
            var configuration = context.Services.GetConfiguration();
            context.Services.Configure<ProSettings>(configuration.GetSection("ProSettings"));
            context.Services.AddScoped<IChartService, ChartService>();
            context.Services.AddScoped<IProjectService, ProjectService>();
            context.Services.AddScoped<IUserService, UserService>();
            context.Services.AddScoped<IAccountService, AccountService>();
            context.Services.AddScoped<IProfileService, ProfileService>();
        }

        private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("AuthServer", options.ProviderOptions);
                options.UserOptions.RoleClaim = JwtClaimTypes.Role;
                options.ProviderOptions.DefaultScopes.Add("Template");
                options.ProviderOptions.DefaultScopes.Add("role");
                options.ProviderOptions.DefaultScopes.Add("email");
                options.ProviderOptions.DefaultScopes.Add("phone");
            });
        }

        private static void ConfigureUI(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
        }

        private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
        {
            context.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri(environment.BaseAddress)
            });
        }

        private void ConfigureAutoMapper(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<TemplateBlazorModule>();
            });
        }
    }
}
