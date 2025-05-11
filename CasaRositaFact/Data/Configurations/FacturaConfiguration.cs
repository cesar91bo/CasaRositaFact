using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaRositaFact.Data.Configurations
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> modelBuilder)
        {
            modelBuilder.HasKey(a => a.IdFactura);

            modelBuilder.HasOne(a => a.TipoDocumentoFiscal) // Relación con Tipos Documentos Fiscales
                .WithMany(c => c.Facturas) // Relación inversa
                .HasForeignKey(a => a.IdTipoDocumentoFiscal) // Clave foránea en Factura
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación 

            modelBuilder.HasOne(a => a.LetraFactura)
                .WithMany(c => c.Facturas)
                .HasForeignKey(a => a.IdLetraFactura)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(a => a.FormaPago)
                .WithMany(c => c.Facturas)
                .HasForeignKey(a => a.IdFormaPago)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(a => a.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(a => a.IdCliente)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(f => f.Usuario)
                .WithMany()
                .HasForeignKey(f => f.IdUsuario)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(f => f.UsuarioAnulacion)
                .WithMany()
                .HasForeignKey(f => f.IdUsuarioAnulacion)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(f => f.Empresa)
                .WithMany()
                .HasForeignKey(f => f.IdEmpresa)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(f => f.Sucursal)
                .WithMany(s => s.Facturas)
                .HasForeignKey(f => f.IdSucursal)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(f => f.ConceptoFactura)
                .WithMany(cf => cf.Facturas)
                .HasForeignKey(f => f.IdConceptoFactura)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
