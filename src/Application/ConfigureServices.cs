using Application.Common.Interfaces;
using Application.Implementations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IFileCreator, FileCreator>();
            services.AddScoped<IFileStreamGetter, FileStreamGetter>();

            return services;
        }
    }
}
