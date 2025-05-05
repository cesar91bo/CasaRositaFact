using CasaRositaFact.Data.Configurations;
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
        public DbSet<Proveedor> Proveedores { get; set; } = null!;
        public DbSet<Rubro> Rubros { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Articulo> Articulos { get; set; } = null!;
        public DbSet<UnidadMedida> UnidadesMedida { get; set; } = null!;
        public DbSet<PrecioArticulo> PreciosArticulos { get; set; } = null!;
        public DbSet<TipoIva> TiposIva { get; set; } = null!;
        public DbSet<Banco> Bancos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration()); // Aplicar configuración de Cliente
            modelBuilder.ApplyConfiguration(new ArticuloConfiguration()); // Aplicar configuración de Articulo
            modelBuilder.ApplyConfiguration(new PrecioArticuloConfiguration()); // Aplicar configuración de PrecioArticulo
            modelBuilder.ApplyConfiguration(new ProveedorConfiguration()); // Aplicar configuración de Proveedor

            // Configuración de RegimenesImpositivos
            modelBuilder.Entity<RegimenImpositivo>().HasKey(r => r.IdRegimenImpositivo); // Clave primaria en RegimenesImpositivos

            // Configuración de TiposDocumentos
            modelBuilder.Entity<TipoDocumento>().HasKey(t => t.IdTipoDocumento); // Clave primaria en TiposDocumentos

            // Configuración de Localidades
            modelBuilder.Entity<Localidad>().HasKey(t => t.IdLocalidad); // Clave primaria en Localidad

            modelBuilder.Entity<Provincia>().HasKey(p => p.IdProvincia); // Clave primaria en Provincias

            modelBuilder.Entity<Rubro>().HasKey(r => r.IdRubro); // Clave primaria en Rubros

            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria); // Clave primaria en Categorías

            modelBuilder.Entity<TipoIva>().HasKey(t => t.IdTipoIva); // Clave primaria en TiposIva

            modelBuilder.Entity<Banco>().HasKey(b => b.IdBanco); // Clave primaria en Bancos
 
        }

    }
}
