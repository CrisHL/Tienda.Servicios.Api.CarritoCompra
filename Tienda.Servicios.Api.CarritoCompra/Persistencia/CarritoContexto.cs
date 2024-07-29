using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.CarritoCompra.Modelo;

namespace Tienda.Servicios.Api.CarritoCompra.Persistencia
{
    public class CarritoContexto: DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options): base(options)
        {

        }

        public DbSet<CarritoSesion> carritoSesiones { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }
    }
}
