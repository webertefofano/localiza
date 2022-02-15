using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza
{
    public partial class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            builder.HasKey(e => e.IdLog);

            builder.ToTable("LOG");

            builder.Property(e => e.IdLog).HasColumnName("ID_LOG");

            builder.Property(e => e.Erro)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("ERRO");

            builder.Property(e => e.Guid).HasColumnName("GUID");

            builder.Property(e => e.Mensagens)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("MENSAGENS");

            builder.Property(e => e.StatusCode).HasColumnName("STATUS_CODE");
        }
    }
}