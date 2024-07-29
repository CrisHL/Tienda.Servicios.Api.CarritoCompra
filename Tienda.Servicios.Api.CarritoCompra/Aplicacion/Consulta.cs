using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.CarritoCompra.Persistencia;
using Tienda.Servicios.Api.CarritoCompra.RemoteInterface;

namespace Tienda.Servicios.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {
            public int CarritoSessionId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto carritoContexto;
            private readonly ILibroService libroService;
            private readonly IAutorService autorService;

            public Manejador(CarritoContexto _carritoContexto, ILibroService _libroService, IAutorService _autorService)
            {
                carritoContexto = _carritoContexto;
                libroService = _libroService;
                autorService = _autorService;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //Ontenemos el carrito almacenado en la base de datos pasando el 
                var carritoSesion = await carritoContexto.carritoSesiones.
                    FirstOrDefaultAsync(x => x.CarritoSesionId ==
                    request.CarritoSessionId);
                //Devuelce la lista de producto detalle solo para conocer el
                var carritoSessionDetalle = await carritoContexto.
                    CarritoSesionDetalle.Where(x => x.CarritoSesionId ==
                    request.CarritoSessionId).ToListAsync();

                var listaCarritoDto = new List<CarritoDetalleDto>();

                foreach (var libro in carritoSessionDetalle)
                {
                    //Invocamos a la microservice externa
                    var response = await libroService.
                        GetLibro(new System.Guid(libro.ProductoSeleccionado));

                    if (response.resultado)
                    {
                        //Se accede si se encuentra algo en la base datos
                        var objectoLibro = response.Libro; // Retorno un libroRemove
                        var responseAutor = await autorService.GetAutor(objectoLibro.AutorLibro);
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            TituloLibro = objectoLibro.Titulo,
                            FechaPublicacion = objectoLibro.FechaPublicacion,
                            LibroId = objectoLibro.LibreriaMaterialId,
                            AutorLibro = $"{responseAutor.Autor.Nombre} {responseAutor.Autor.Apellido}"
                        };
                        listaCarritoDto.Add(carritoDetalle);
                    }
                }
                if (carritoSesion != null && carritoSessionDetalle != null)
                {
                    // Llenamos el objet que realmente es necesario retornar
                    var carritoSessionDto = new CarritoDto
                    {
                        CarritoId = carritoSesion.CarritoSesionId,
                        FechaCreacionSesion = carritoSesion.FechaCreacion,
                        ListaDeProductos = listaCarritoDto
                    };
                    return carritoSessionDto;
                }
                return null;

            }

        }
    }

}
