using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Services;

namespace ECommerce.Api.Configurations
{

    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
