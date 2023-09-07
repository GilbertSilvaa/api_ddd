using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // usado para criar as Migrations
            string conn = "Server=localhost;Database=ApiDotNet;Uid=root;Pwd=Ringkyu777#";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

            return new MyContext(optionsBuilder.Options);
        }
    }
}
