using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Api.Data.Repositories;
using Api.Domain.Interfaces;
using Api.Data.Context;
using Api.Domain.Repositories;
using Api.Data.Implementations;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            string conn = "Server=localhost;Database=ApiDotNet;Uid=root;Pwd=Ringkyu777#;";
            serviceCollection.AddDbContext<MyContext>(options =>
                options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
        }
    }
}
