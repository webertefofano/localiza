using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class VeiculoMap
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(e => e.IdVeiculo);

            builder.ToTable("VEICULO");

            builder.Property(e => e.IdVeiculo).HasColumnName("ID_VEICULO");

            builder.Property(e => e.Placa)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PLACA");

            builder.Property(e => e.AnoFabricacao).HasColumnName("ANO_FABRICACAO");

            builder.Property(e => e.AnoModelo).HasColumnName("ANO_MODELO");
                        
            builder.Property(e => e.IdModelo).HasColumnName("ID_MODELO");

            builder.HasOne(d => d.IdModeloNavigation)
                .WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VEICULO_MODELO");
        }
    }
}