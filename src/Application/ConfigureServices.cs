using Application.Implementations;
using Application.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IFileCreator, FileCreator>();
            services.AddScoped<IFileGetter, FileGetter>();

            return services;
        }
    }
}
