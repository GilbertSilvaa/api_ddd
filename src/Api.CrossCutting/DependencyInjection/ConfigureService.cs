using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Api.Domain.Interfaces.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
