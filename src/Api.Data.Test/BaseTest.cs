using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class BaseTest
    {
        public BaseTest() { }
    }

    public class DbTest : IDisposable
    {
        private readonly string _dbName;

        public ServiceProvider ServiceProvider { get; private set; } = null!;

        public DbTest()
        {
            string dbName = Guid.NewGuid().ToString().Replace("-", string.Empty);
            _dbName = $"dbApiTest_{dbName}";

            string conn = $"Persist Security Server=localhost;Database={_dbName};Uid=root;Pwd=Ringkyu777#;";
            var serviceColletion = new ServiceCollection();

            serviceColletion.AddDbContext<MyContext>(o =>
                o.UseMySql(conn, ServerVersion.AutoDetect(conn)),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceColletion.BuildServiceProvider();
            using var context = ServiceProvider.GetService<MyContext>();
            context?.Database.EnsureCreated();
        }

        public void Dispose()
        {
            using var context = ServiceProvider.GetService<MyContext>();
            context?.Database.EnsureDeleted();
        }
    }
}
