using AutoMapper;
using Ecommerce.API.Configurations.Notifications;
using Ecommerce.DATA.Repositories;
using Ecommerce.DOMAIN.Interfaces.INotifier;
using Ecommerce.DOMAIN.Interfaces.IRepository;
using Ecommerce.DOMAIN.Interfaces.IServices;
using Ecommerce.DOMAIN.Services;

namespace Ecommerce.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<INotifier, Notifier>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
