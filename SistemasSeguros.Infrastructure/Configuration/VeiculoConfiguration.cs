using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasSeguros.Domain.Aggregates.Veiculos;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;

namespace SistemasSeguros.Infrastructure.Configuration
{
    public sealed class VeiculoConfiguration: IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("VEICULO");
            builder.Property(b => b.SeguroId)
                .HasConversion(v => v.Id, v => new SeguroId(v))
                .HasMaxLength(60)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .HasColumnName("SEGUROID");
            builder.Property(b => b.VeiculoId).HasConversion(v => v.Id, v => new VeiculoId(v)).HasMaxLength(60).IsRequired().HasColumnName("VEICULOID");
            builder.Property(b => b.Marca).HasMaxLength(15).IsRequired().HasColumnName("MARCA");
            builder.Property(b => b.Modelo).HasMaxLength(15).IsRequired().HasColumnName("MODELO");
            builder.Property(b => b.ValorDoVeiculo).HasMaxLength(15).IsRequired().HasColumnName("VALORDOVEICULO");

        }
    }
}
