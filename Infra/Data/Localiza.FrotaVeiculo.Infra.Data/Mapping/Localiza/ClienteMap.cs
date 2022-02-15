using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            builder.HasKey(e => e.IdCliente);

            builder.ToTable("CLIENTE");

            builder.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

            builder.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BAIRRO");

            builder.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CIDADE");

            builder.Property(e => e.Cpf).HasColumnName("CPF");

            builder.Property(e => e.DataNacimento).HasColumnName("DATA_NACIMENTO");

            builder.Property(e => e.Endereco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENDERECO");

            builder.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ESTADO")
                .IsFixedLength(true);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");

            builder.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("NUMERO")
                .IsFixedLength(true);

            builder.Property(e => e.NumeroCnh).HasColumnName("NUMERO_CNH");
        }
    }
}