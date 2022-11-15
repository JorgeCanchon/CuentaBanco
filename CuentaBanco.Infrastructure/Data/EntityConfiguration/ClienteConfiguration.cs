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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Cliente", "dbo");
            entityTypeBuilder.Property(propiedad => propiedad.ID).HasColumnName("ID");
            entityTypeBuilder.Property(propiedad => propiedad.Contrasena).HasColumnName("Contrasena");
            entityTypeBuilder.Property(propiedad => propiedad.Estado).HasColumnName("Estado");
        }
    }
}
