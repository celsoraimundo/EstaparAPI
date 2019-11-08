using Estapar.Domain.Entities;
using Estapar.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Estapar.Infra.Data.Context
{
    public partial class essenceestaparContext : DbContext
    {
        private readonly string connectionString;
        public essenceestaparContext()
        {
        }
        
        public essenceestaparContext(DbContextOptions<essenceestaparContext> options)
            : base(options)
        {
           
        }

        public DbSet<Manobrista> Manobrista { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<VeiculoManobra> VeiculoManobra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manobrista>(new ManobristaMap().Configure);

            modelBuilder.Entity<Veiculo>(new VeiculoMap().Configure);

            modelBuilder.Entity<VeiculoManobra>(new VeiculoManobraMap().Configure);

            base.OnModelCreating(modelBuilder);
        }
    }
}