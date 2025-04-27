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
        public DbSet<RegimenesImpositivos> RegimenesImpositivos { get; set; } = null!;
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
                .WithMany()  // Asumiendo que no necesitas la relación inversa (si la necesitas, puedes usar WithMany(r => r.Clientes))
                .HasForeignKey(c => c.IdRegimenImpositivo) // Clave foránea en Cliente
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminar un régimen (opcional, depende de tus necesidades)

            // Configuración de RegimenesImpositivos
            modelBuilder.Entity<RegimenesImpositivos>()
                .HasKey(r => r.IdRegimenImpositivo); // Clave primaria en RegimenesImpositivos

            modelBuilder.Entity<RegimenesImpositivos>()
                .Property(r => r.Descripcion)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
