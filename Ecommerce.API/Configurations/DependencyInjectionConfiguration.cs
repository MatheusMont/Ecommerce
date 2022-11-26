﻿using Ecommerce.API.Configurations.Notifications;
using Ecommerce.DOMAIN.Interfaces.IServices;
using Ecommerce.DOMAIN.Services;

namespace Ecommerce.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
