using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using CuentaBanco.Core.Entities;
using CuentaBanco.Infrastructure.Data.EntityConfiguration;
using CuentaBanco.Core.Models;

namespace CuentaBanco.Infrastructure.Data.EntityFrameworkSQL
{
    public class RepositoryContextSQL : DbContext
    {

        public RepositoryContextSQL()
        {

        }

        public RepositoryContextSQL(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<ReporteEstadoCuenta> Reportes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder != null)
            {
                modelBuilder.HasAnnotation("Sqlite:Autoincement", true)
                    .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                modelBuilder.ApplyConfiguration(new ClienteConfiguration());
                modelBuilder.ApplyConfiguration(new PersonaConfiguration());
                modelBuilder.ApplyConfiguration(new CuentaConfiguration());
            }
        }
    }
}
