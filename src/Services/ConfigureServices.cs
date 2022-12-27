using Microsoft.Extensions.Configuration;
using Services.Implementations;
using Services.Interfaces;
using Services.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServiceLayerServices(this IServiceCollection services, IConfiguration config)
        {
            //Getting directory path through Options
            services.Configure<DirectoryOptions>(config.GetSection(DirectoryOptions.Directory));
            services.AddScoped<ICreateFileService, CreateFileService>(); 
            services.AddScoped<IGetFileService, GetFileService>();

            return services;
        }
    }
}
