using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class UsuarioPermissaoMap : IEntityTypeConfiguration<UsuarioPermissao>
    {
        public void Configure(EntityTypeBuilder<UsuarioPermissao> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            builder.HasKey(e => e.IdUsuarioPermissao);

            builder.ToTable("USUARIO_PERMISSAO");

            builder.Property(e => e.IdUsuarioPermissao).HasColumnName("ID_USUARIO_PERMISSAO");

            builder.Property(e => e.IdPermissao).HasColumnName("ID_PERMISSAO");

            builder.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            builder.HasOne(d => d.IdPermissaoNavigation)
                .WithMany(p => p.UsuarioPermissaos)
                .HasForeignKey(d => d.IdPermissao)
                .HasConstraintName("FK_USUARIO_PERMISSAO_PERMISSAO");
        }
    }
}