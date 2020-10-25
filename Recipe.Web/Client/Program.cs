using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Recipe.Web.Data;
using Blazored.SessionStorage;
using Syncfusion.Blazor;


namespace Recipe.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<Blazored.SessionStorage.ISessionStorageService, Blazored.SessionStorage.SessionStorageService>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            await builder.Build().RunAsync();
        }
    }
}
