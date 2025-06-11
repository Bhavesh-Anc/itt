using JobApplicationPortal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JobApplicationPortal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register your application services here
            services.AddScoped<IJobService, JobService>();
            services.AddTransient<IEmailService, EmailService>();
            
            return services;
        }
    }
}
