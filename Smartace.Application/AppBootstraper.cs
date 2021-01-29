using Microsoft.Extensions.DependencyInjection;
using Smartace.Application.Services.AuthService.Concrete;
using Smartace.Application.Services.AuthService.Interface;


namespace Smartace.Application
{
    public static class AppBootstraper
    {
        public static void InitServices(IServiceCollection services)
        {
            AutoInjectLayers(services);
            services.AddTransient<ITokenGenerator, JWTTokenGenerator>();
        }


        private static void AutoInjectLayers(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(scan => scan.FromCallingAssembly().AddClasses(classes => classes
                    .Where(type => type.Name.EndsWith("Repository") || type.Name.EndsWith("Service")), false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        }
    }
}
