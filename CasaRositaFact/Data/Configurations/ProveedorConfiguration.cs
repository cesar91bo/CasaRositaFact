using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CasaRositaFact.Data.Configurations
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.HasKey(p => p.IdProveedor);

            builder.HasOne(p => p.Banco) // Relación con Banco
                .WithMany(b => b.Proveedores) // Relación inversa
                .HasForeignKey(p => p.IdBanco) // Clave foránea en Proveedor
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación
        }
    }
}
