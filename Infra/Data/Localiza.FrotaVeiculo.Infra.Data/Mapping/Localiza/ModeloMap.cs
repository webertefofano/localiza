using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            builder.HasKey(e => e.IdModelo);

            builder.ToTable("MODELO");

            builder.Property(e => e.IdFabricante).HasColumnName("ID_FABRICANTE");

            builder.Property(e => e.IdModelo).HasColumnName("ID_MODELO");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOME");

            builder.Property(e => e.Peso).HasColumnName("PESO");

            builder.HasOne(d => d.IdFabricanteNavigation)
                   .WithMany(p => p.Modelos)
                   .HasForeignKey(d => d.IdFabricante)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MODELO_FABRICANTE");
        }
    }
}