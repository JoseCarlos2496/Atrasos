using System.Reflection;
using Atrasos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Atrasos.Infrastructure.Data
{
    public class AtrasosDBContext : DbContext
    {
        public AtrasosDBContext() : base() { }

        public AtrasosDBContext(DbContextOptions<AtrasosDBContext> options) : base(options) { }

        public DbSet<Atraso> Atraso { get; set; }

        public void OnConfigurating(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
