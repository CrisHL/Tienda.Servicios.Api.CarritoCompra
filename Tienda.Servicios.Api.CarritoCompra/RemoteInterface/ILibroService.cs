using Tienda.Servicios.Api.CarritoCompra.RemoteModel;

namespace Tienda.Servicios.Api.CarritoCompra.RemoteInterface
{
    public interface ILibroService
    {
        Task<(bool resultado, LibroRemote Libro, string ErrorMessage)> GetLibro(Guid LibroId);
    }
}
