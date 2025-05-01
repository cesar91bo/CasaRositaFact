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

            modelBuilder.Entity<Proveedor>()
                .HasKey(p => p.IdProveedor); // Clave primaria en Proveedores

            modelBuilder.Entity<Rubro>()
                .HasKey(r => r.IdRubro); // Clave primaria en Rubros

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.IdCategoria); // Clave primaria en Categorías

            modelBuilder.Entity<Articulo>()
                .HasKey(a => a.IdArticulo); // Clave primaria en Artículos

            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.Categoria) // Relación con Categoría
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdCategoria) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación 

            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.Proveedor) // Relación con Proveedor
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdProveedor) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación 

            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.Rubro) // Relación con Rubro
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdRubro) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación 

            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.UnidadMedida) // Relación con UnidadMedida
                .WithMany(c => c.Articulos) // Relación inversa
                .HasForeignKey(a => a.IdUnidadMedida) // Clave foránea en Artículo
                .OnDelete(DeleteBehavior.SetNull); // Comportamiento en caso de eliminación
        }

    }
}
