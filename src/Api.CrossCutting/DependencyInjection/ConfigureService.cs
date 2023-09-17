using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Interfaces.Services.Country;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Uf;
using Api.Service.Services;
using service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<ICountryService, CountryService>();
            serviceCollection.AddTransient<ICepService, CepService>();
        }
    }
}
