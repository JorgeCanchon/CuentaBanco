using CuentaBanco.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Data.EntityConfiguration
{
    public class MovimientosConfiguration : IEntityTypeConfiguration<Movimientos>
    {
        public void Configure(EntityTypeBuilder<Movimientos> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Movimientos", "dbo");
            entityTypeBuilder.HasKey(propiedad => new { propiedad.ID });
            entityTypeBuilder.Property(propiedad => propiedad.TipoMovimiento).HasColumnName("TipoMovimiento");
            entityTypeBuilder.Property(propiedad => propiedad.Fecha).HasColumnName("Fecha");
            entityTypeBuilder.Property(propiedad => propiedad.Valor).HasColumnName("Valor");
            entityTypeBuilder.Property(propiedad => propiedad.Saldo).HasColumnName("Saldo");
            entityTypeBuilder.Property(propiedad => propiedad.IDCliente).HasColumnName("IDCliente");
        }
    }
}
