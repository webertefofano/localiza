using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            builder.HasKey(e => e.IdUsuario);

            builder.ToTable("USUARIO");

            builder.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            builder.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOGIN");

            builder.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");            
        }
    }
}