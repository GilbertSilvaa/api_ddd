using Microsoft.EntityFrameworkCore;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Api.Data.Seeds;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<CountryEntity>(new CountryMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            // create standard user
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    Email = "adm@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            // create standards ufs
            UfSeeds.Ufs(modelBuilder);
        }
    }
}
