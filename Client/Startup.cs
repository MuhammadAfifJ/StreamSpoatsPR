using StreamSpoatsPR.Client.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using StreamSpoatsPR.Client.Authentication;

namespace StreamSpoatsPR.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddScoped<IAuthService, AuthService>();

        }

        //public void Configure(IComponentsApplicationBuilder app)
        //{
        //    app.AddComponent<App>("app");
        //}
    }
}
