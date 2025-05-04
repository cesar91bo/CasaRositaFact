using CasaRositaFact.Components;
using CasaRositaFact.Data;
using CasaRositaFact.Data.IRepositories;
using CasaRositaFact.Data.Repositories;
using CasaRositaFact.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Configuracion de Razor Pages
builder.Services.AddRazorPages();

//Configuracion de entity framework core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<RegimenService>();
builder.Services.AddScoped<IRegimenRepository, RegimenRepository>();

builder.Services.AddScoped<ProvinciaService>();
builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();

builder.Services.AddScoped<LocalidadService>();
builder.Services.AddScoped<ILocalidadRepository, LocalidadRepository>();

builder.Services.AddScoped<ArticuloService>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();

builder.Services.AddScoped<PrecioArticuloService>();
builder.Services.AddScoped<IPrecioArticuloRepository, PrecioArticuloRepository>();

builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped<ProveedorService>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();

builder.Services.AddScoped<RubroService>();
builder.Services.AddScoped<IRubroRepository, RubroRepository>();

builder.Services.AddScoped<UnidadMedidaService>();
builder.Services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapRazorPages();

app.Run();
