using Microsoft.EntityFrameworkCore;

namespace TestTaskETL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SampleDataEntity> SampleData { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer({ConnectionString});

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleDataEntity>().HasIndex(u => u.PULocationId);
            modelBuilder.Entity<SampleDataEntity>().HasIndex(f => f.FareAmount);
        }

    }


}
