using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaRositaFact.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> modelBuilder)
        {
            modelBuilder.HasKey(e => e.IdEmpresa); // Clave primaria en Empresas

            modelBuilder.HasOne(e => e.Parametro)
                .WithOne(p => p.Empresa)
                .HasForeignKey<Parametro>(p => p.IdEmpresa)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
