using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.CarritoCompra.Aplicacion;
using Tienda.Servicios.Api.CarritoCompra.Persistencia;
using Tienda.Servicios.Api.CarritoCompra.RemoteInterface;
using Tienda.Servicios.Api.CarritoCompra.RemoteServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarritoContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<IAutorService, AutorService>();
builder.Services.AddHttpClient("Libros", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:Libros"]);
});
builder.Services.AddHttpClient("Autores", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:Autores"]);
});

builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
builder.Services.AddAutoMapper(typeof(Consulta.Manejador));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
