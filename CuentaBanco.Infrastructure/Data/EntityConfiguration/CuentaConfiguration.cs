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
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Cuenta", "dbo");
            entityTypeBuilder.HasKey(propiedad => new { propiedad.ID });
            entityTypeBuilder.Property(propiedad => propiedad.NumeroCuenta).HasColumnName("NumeroCuenta");
            entityTypeBuilder.Property(propiedad => propiedad.TipoCuenta).HasColumnName("TipoCuenta");
            entityTypeBuilder.Property(propiedad => propiedad.SaldoInicial).HasColumnName("SaldoInicial");
            entityTypeBuilder.Property(propiedad => propiedad.Estado).HasColumnName("Estado");
            entityTypeBuilder.Property(propiedad => propiedad.IDCliente).HasColumnName("IDCliente");
        }
    }
}
