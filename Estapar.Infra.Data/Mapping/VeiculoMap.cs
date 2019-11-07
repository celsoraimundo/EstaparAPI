using Estapar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.Infra.Data.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");

            builder.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

        }
    }
}

