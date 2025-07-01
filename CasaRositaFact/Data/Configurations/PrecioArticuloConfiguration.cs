using CasaRositaFact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaRositaFact.Data.Configurations
{
    public class PrecioArticuloConfiguration : IEntityTypeConfiguration<PrecioArticulo>
    {
        public void Configure(EntityTypeBuilder<PrecioArticulo> modelBuilder)
        {
            modelBuilder.HasKey(p => p.IdPrecioArticulo); // Clave primaria en PreciosArticulos

            modelBuilder.HasOne(p => p.Articulo) // Relación con Articulo
                .WithMany(a => a.PreciosArticulos) // Relación inversa
                .HasForeignKey(p => p.IdArticulo) // Clave foránea en PrecioArticulo
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento en caso de eliminación

            modelBuilder.HasOne(p => p.TipoIva)
                .WithMany()
                .HasForeignKey(p => p.IdTipoIva)
                .IsRequired(false) // La relación es opcional
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
