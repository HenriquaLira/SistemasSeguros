using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasSeguros.Domain.Aggregates.Segurados;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;

namespace SistemasSeguros.Infrastructure.Configuration
{
    public sealed class SeguradoConfiguration : IEntityTypeConfiguration<Segurado>
    {
        public void Configure(EntityTypeBuilder<Segurado> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("SEGURADO");
            builder.Property(b => b.SeguroId)
                .HasConversion(v => v.Id, v => new SeguroId(v))
                .HasMaxLength(60)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .HasColumnName("SEGUROID");
            builder.Property(b => b.SeguradoId).HasConversion(v => v.Id, v => new SeguradoId(v)).HasMaxLength(60).IsRequired().HasColumnName("SEGURADOID");
            builder.Property(b => b.Nome).HasMaxLength(15).IsRequired().HasColumnName("NOME");
            builder.Property(b => b.Idade).HasMaxLength(15).IsRequired().HasColumnName("IDADE");
            builder.Property(b => b.Cpf).HasMaxLength(15).IsRequired().HasColumnName("CPF");

        }
    }
}
