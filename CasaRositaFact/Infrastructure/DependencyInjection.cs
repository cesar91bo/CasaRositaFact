using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Data.Repositories;
using CasaRositaFact.Services;

namespace CasaRositaFact.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<RegimenService>();
            services.AddScoped<IRegimenRepository, RegimenRepository>();

            services.AddScoped<ProvinciaService>();
            services.AddScoped<IProvinciaRepository, ProvinciaRepository>();

            services.AddScoped<LocalidadService>();
            services.AddScoped<ILocalidadRepository, LocalidadRepository>();

            services.AddScoped<ArticuloService>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();

            services.AddScoped<PrecioArticuloService>();
            services.AddScoped<IPrecioArticuloRepository, PrecioArticuloRepository>();

            services.AddScoped<CategoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<ProveedorService>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();

            services.AddScoped<RubroService>();
            services.AddScoped<IRubroRepository, RubroRepository>();

            services.AddScoped<UnidadMedidaService>();
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();

            services.AddScoped<BancoService>();
            services.AddScoped<IBancoRepository, BancoRepository>();

            services.AddScoped<EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<ParametroService>();
            services.AddScoped<IParametroRepository, ParametroRepository>();

            services.AddScoped<FacturaService>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();

            services.AddScoped<FacturaDetalleService>();
            services.AddScoped<IFacturaDetalleRepository, FacturaDetalleRepository>();

            services.AddScoped<AuxiliarService>();
            services.AddScoped<IAuxiliarRepository, AuxiliarRepository>();

            return services;
        }
    }
}
