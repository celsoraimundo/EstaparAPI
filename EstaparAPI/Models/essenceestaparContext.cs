using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstaparAPI.Models
{
    public partial class essenceestaparContext : DbContext
    {
        public essenceestaparContext()
        {
        }

        public essenceestaparContext(DbContextOptions<essenceestaparContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Manobrista> Manobrista { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<VeiculoManobra> VeiculoManobra { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manobrista>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VeiculoManobra>(entity =>
            {
                entity.Property(e => e.DataHoraManobra).HasColumnType("datetime");

                entity.HasOne(d => d.IdManobristaNavigation)
                    .WithMany(p => p.VeiculoManobra)
                    .HasForeignKey(d => d.IdManobrista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VeiculoManobra_Manobrista");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.VeiculoManobra)
                    .HasForeignKey(d => d.IdVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VeiculoManobra_Veiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
