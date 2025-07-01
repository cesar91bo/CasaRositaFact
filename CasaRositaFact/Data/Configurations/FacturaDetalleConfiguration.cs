using CasaRositaFact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaRositaFact.Data.Configurations
{
    public class FacturaDetalleConfiguration : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> modelBuilder)
        {
            modelBuilder.HasKey(fd => fd.IdFacturaDetalle); // Clave primaria en FacturaDetalles
            modelBuilder.HasOne(fd => fd.Factura) // Relación con Factura
                .WithMany(f => f.Detalles) // Relación inversa
                .HasForeignKey(fd => fd.IdFactura) // Clave foránea en FacturaDetalle
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento en caso de eliminación

            modelBuilder.HasOne(fd => fd.Articulo) // Relación con Articulo
                .WithMany(a => a.FacturaDetalles) // Relación inversa
                .HasForeignKey(fd => fd.IdArticulo) // Clave foránea en FacturaDetalle
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento en caso de eliminación

            modelBuilder.HasOne(fd => fd.UnidadMedida) // Relación con UnidadMedida
                .WithMany() // Relación inversa
                .HasForeignKey(fd => fd.IdUnidadMedida) // Clave foránea en FacturaDetalle
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento en caso de eliminación

            modelBuilder.HasOne(fd => fd.TipoIva) // Relación con TipoIva
                .WithMany() // Relación inversa
                .HasForeignKey(fd => fd.IdTipoIva) // Clave foránea en FacturaDetalle
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento en caso de eliminación
        }
    }
}
