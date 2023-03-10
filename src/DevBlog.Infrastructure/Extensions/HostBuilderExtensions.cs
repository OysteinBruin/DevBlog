using DevBlog.Infrastructure.Interfaces;
using DevBlog.Infrastructure.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace DevBlog.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {

        public static WebAssemblyHostBuilder AddServices(this WebAssemblyHostBuilder builder)
        {
            builder
                .Services
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddTransient<IBlogPostService, BlogPostService>();

            return builder;
        }
    }
}
