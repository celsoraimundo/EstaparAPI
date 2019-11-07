using Estapar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estapar.Infra.Data.Mapping
{
    public class VeiculoManobraMap : IEntityTypeConfiguration<VeiculoManobra>
    {
        public void Configure(EntityTypeBuilder<VeiculoManobra> builder)
        {
            builder.ToTable("VeiculoManobra");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.DataHoraManobra).HasColumnType("datetime");

            builder.HasOne(d => d.IdManobristaNavigation)
                .WithMany(p => p.VeiculoManobra)
                .HasForeignKey(d => d.IdManobrista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VeiculoManobra_Manobrista");

            builder.HasOne(d => d.IdVeiculoNavigation)
                .WithMany(p => p.VeiculoManobra)
                .HasForeignKey(d => d.IdVeiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VeiculoManobra_Veiculo");
        }
    }
}