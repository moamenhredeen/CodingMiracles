using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Db;

namespace api.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();
            services.AddScoped<IPostService, PostService>(); 
        }
    }
    
}