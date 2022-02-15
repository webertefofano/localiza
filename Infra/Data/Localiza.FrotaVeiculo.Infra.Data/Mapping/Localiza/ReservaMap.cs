using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class ReservaMap
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            builder.HasKey(e => e.IdReserva);

            builder.ToTable("RESERVA");

            builder.Property(e => e.IdReserva).HasColumnName("ID_RESERVA");

            builder.Property(e => e.Data).HasColumnName("DATA");

            builder.Property(e => e.DataDevolucao).HasColumnName("DATA_DEVOLUCAO");

            builder.Property(e => e.DataPrevistaDevolucao).HasColumnName("DATA_PREVISTA_DEVOLUCAO");

            builder.Property(e => e.DataRetirada).HasColumnName("DATA_RETIRADA");

            builder.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

            builder.Property(e => e.IdVeiculo).HasColumnName("ID_VEICULO");

            builder.Property(e => e.VeiculoRetirado).HasColumnName("VEICULO_RETIRADO");

            builder.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVA_CLIENTE");

            builder.HasOne(d => d.IdVeiculoNavigation)
                .WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdVeiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVA_VEICULO");
        }
    }
}