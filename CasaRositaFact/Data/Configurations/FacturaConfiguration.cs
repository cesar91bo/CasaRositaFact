using CasaRositaFact.Data.Entities;
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
                .OnDelete(DeleteBehavior.Restrict); // Comportamiento en caso de eliminación 

            modelBuilder.HasOne(a => a.LetraFactura)
                .WithMany(c => c.Facturas)
                .HasForeignKey(a => a.IdLetraFactura)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(a => a.FormaPago)
                .WithMany(c => c.Facturas)
                .HasForeignKey(a => a.IdFormaPago)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(a => a.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(a => a.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(f => f.UsuarioGenerador)
                .WithMany(u => u.FacturasGeneradas)
                .HasForeignKey(f => f.IdUsuario)
                .HasPrincipalKey(u => u.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(f => f.UsuarioAnulador)
                .WithMany(u => u.FacturasAnuladas)
                .HasForeignKey(f => f.IdUsuarioAnulacion)
                .HasPrincipalKey(u => u.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(f => f.Empresa)
                .WithMany()
                .HasForeignKey(f => f.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(f => f.Sucursal)
                .WithMany(s => s.Facturas)
                .HasForeignKey(f => f.IdSucursal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(f => f.ConceptoFactura)
                .WithMany(cf => cf.Facturas)
                .HasForeignKey(f => f.IdConceptoFactura)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
