using CasaRositaFact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaRositaFact.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Apellido)
                .IsRequired()
                .HasMaxLength(100);
            // Relación con el régimen impositivo
            builder.HasOne(c => c.RegimenImpositivo)
                .WithMany()
                .HasForeignKey(c => c.IdRegimenImpositivo)
                .OnDelete(DeleteBehavior.Cascade);
            // Relación con el TipoDocumento
            builder.HasOne(c => c.TipoDocumento)
                .WithMany()
                .HasForeignKey(c => c.IdTipoDocumento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
