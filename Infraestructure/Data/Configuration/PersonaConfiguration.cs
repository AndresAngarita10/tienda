using System.Globalization;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("persona");

            builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTipoPersonaFk);

            builder.HasOne(p => p.Region)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdRegionFk);

            builder
            .HasMany(p => p.Productos)
            .WithMany(p => p.Personas)
            .UsingEntity <ProductoPersona>(
                j => j 
                    .HasOne(pt => pt.Producto)
                    .WithMany(t => t.ProductosPersonas)
                    .HasForeignKey(pt => pt.IdProductoFk),
                j => j
                    .HasOne(pt => pt.Persona)
                    .WithMany(t => t.ProductosPersonas)
                    .HasForeignKey(pt => pt.IdPersonaFk),
                j => 
                {
                    j.HasKey(t => new { t.IdProductoFk, t.IdPersonaFk});
                }
            );

      /*       builder.HasKey(e => );
            builder.Property(e => ); */
        }
    }
}