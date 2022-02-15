using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Infra.Data.Mapping.Localiza;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Localiza.FrotaVeiculo.Infra.Data.Context.Localiza
{
    public partial class ContextLocaliza : DbContext
    {
        public ContextLocaliza()
        {
        }

        public ContextLocaliza(DbContextOptions<ContextLocaliza> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Fabricante> Fabricantes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Permissao> Permissaos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPermissao> UsuarioPermissaos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.            
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);

            modelBuilder.Entity<Fabricante>(new FabricanteMap().Configure);

            modelBuilder.Entity<Log>(new LogMap().Configure);

            modelBuilder.Entity<Modelo>(new ModeloMap().Configure);

            modelBuilder.Entity<Permissao>(new PermissaoMap().Configure);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);

            modelBuilder.Entity<UsuarioPermissao>(new UsuarioPermissaoMap().Configure);

            modelBuilder.Entity<Reserva>(new ReservaMap().Configure);

            modelBuilder.Entity<Veiculo>(new VeiculoMap().Configure);
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}