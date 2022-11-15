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
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Persona", "dbo");
            entityTypeBuilder.HasKey(propiedad => new { propiedad.ID });
            entityTypeBuilder.Property(propiedad => propiedad.Nombre).HasColumnName("Nombre");
            entityTypeBuilder.Property(propiedad => propiedad.Genero).HasColumnName("Genero");
            entityTypeBuilder.Property(propiedad => propiedad.FechaNacimiento).HasColumnName("FechaNacimiento");
            entityTypeBuilder.Property(propiedad => propiedad.Identificacion).HasColumnName("Identificacion");
            entityTypeBuilder.Property(propiedad => propiedad.Direccion).HasColumnName("Direccion");
            entityTypeBuilder.Property(propiedad => propiedad.Telefono).HasColumnName("Telefono");
        }
    }
}
