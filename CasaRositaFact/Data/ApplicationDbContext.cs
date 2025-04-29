using CasaRositaFact.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaRositaFact.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<RegimenImpositivo> RegimenesImpositivos { get; set; } = null!;
        public DbSet<TipoDocumento> TiposDocumentos { get; set; } = null!;
        public DbSet<Localidad> Localidades { get; set; } = null!;
        public DbSet<Provincia> Provincias { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.IdCliente);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            // Relación con el régimen impositivo
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.RegimenImpositivo) // Relación de Cliente con RegimenImpositivo
                .WithMany()  // Si el régimen tiene una lista de clientes, puedes usar .WithMany(r => r.Clientes)
                .HasForeignKey(c => c.IdRegimenImpositivo) // Clave foránea en Cliente
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento en caso de eliminar un régimen (opcional)

            // Relación con el TipoDocumento
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.TipoDocumento) // Relación con TipoDocumento
                .WithMany() // Si TipoDocumento tiene una lista de Clientes, puedes usar .WithMany(t => t.Clientes)
                .HasForeignKey(c => c.IdTipoDocumento) // Clave foránea en Cliente
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento en caso de eliminación (puedes cambiarlo según lo necesites)

            // Configuración de RegimenesImpositivos
            modelBuilder.Entity<RegimenImpositivo>()
                .HasKey(r => r.IdRegimenImpositivo); // Clave primaria en RegimenesImpositivos

            // Configuración de TiposDocumentos
            modelBuilder.Entity<TipoDocumento>()
                .HasKey(t => t.IdTipoDocumento); // Clave primaria en TiposDocumentos

            // Configuración de Localidades
            modelBuilder.Entity<TipoDocumento>()
                .HasKey(t => t.IdTipoDocumento); // Clave primaria en TiposDocumentos

            modelBuilder.Entity<Provincia>()
                .HasKey(p => p.IdProvincia); // Clave primaria en Provincias
        }

    }
}
