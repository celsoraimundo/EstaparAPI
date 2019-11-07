using Estapar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.Infra.Data.Mapping
{
    public class ManobristaMap : IEntityTypeConfiguration<Manobrista>
    {
        public void Configure(EntityTypeBuilder<Manobrista> builder)
        {
            builder.ToTable("Manobrista");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");

            builder.Property(e => e.DataNascimento).HasColumnType("date");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
