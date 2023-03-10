using Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Infrastructure.Authentication;
using Infrastructure.Files;
using Infrastructure.Options;
using Application.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServiceLayerServices(this IServiceCollection services, IConfiguration config)
        {
            //Getting directory path through Options
            services.Configure<DirectoryOptions>(config.GetSection(DirectoryOptions.Directory));
            services.AddScoped<IFileCreator, FileCreator>();
            services.AddScoped<IFileGetter, FileGetter>();
            services.AddScoped<IFileCreateService, CreateTxtFileService>(); 
            services.AddScoped<IFileGetService, FileGetService>();
            services.AddScoped<IJwtAuthorizationService, JwtAuthorizationService>();

            return services;
        }
    }
}