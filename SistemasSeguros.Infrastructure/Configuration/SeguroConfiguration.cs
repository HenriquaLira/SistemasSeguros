using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasSeguros.Infrastructure.Configuration
{
    public sealed class SeguroConfiguration : IEntityTypeConfiguration<Seguro>
    {
        public void Configure(EntityTypeBuilder<Seguro> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("SEGURO");
            builder.Property(b => b.SeguroId).HasConversion(
                v => v.Id,
                v => new SeguroId(v)).HasMaxLength(60).IsRequired().HasColumnName("SEGUROID");

            builder.Property(b => b.TaxaRisco).HasColumnName("TAXARISCO");
            builder.Property(b => b.PremioComercial).HasColumnName("PREMIOCOMERCIAL");
            builder.Property(b => b.PremioPuro).HasColumnName("PREMIOPURO");
            builder.Property(b => b.PremioRisco).HasColumnName("PREMIORISCO");

            builder.HasOne(x => x.Segurado)
            .WithOne(b => b.Seguro!)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Veiculo)
                .WithOne(b => b.Seguro!)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
