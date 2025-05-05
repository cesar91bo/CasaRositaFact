using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaRositaFact.Data.Configurations
{
    public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> modelBuilder)
        {
            modelBuilder.HasKey(a => a.IdArticulo);

            modelBuilder.HasOne(a => a.Categoria)
                .WithMany(a => a.Articulos)
                .HasForeignKey(a => a.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasOne(a => a.Categoria) // Relación con Categoría
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdCategoria) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación 

            modelBuilder.HasOne(a => a.Proveedor) // Relación con Proveedor
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdProveedor) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación 

            modelBuilder.HasOne(a => a.Rubro) // Relación con Rubro
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdRubro) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación 

            modelBuilder.HasOne(a => a.UnidadMedida) // Relación con UnidadMedida
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdUnidadMedida) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación

        }
    }
}
