using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class PermissaoMap : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            builder.HasKey(e => e.IdPermissao);

            builder.ToTable("PERMISSAO");

            builder.Property(e => e.IdPermissao).HasColumnName("ID_PERMISSAO");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOME");
        }
    }
}