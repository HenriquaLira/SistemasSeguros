using Microsoft.EntityFrameworkCore;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.Veiculos;
using SistemasSeguros.Domain.Aggregates.Segurados;
using System;

namespace SistemasSeguros.Infrastructure
{
    public class SisSeguroContext : DbContext
    {

        public SisSeguroContext(DbContextOptions options)
            : base(options)
        {
        }


        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Segurado> Segurados { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SisSeguroContext).Assembly);
            modelBuilder.Entity<Seguro>();
            modelBuilder.Entity<Segurado>();
            modelBuilder.Entity<Veiculo>();
        }
    }
}
