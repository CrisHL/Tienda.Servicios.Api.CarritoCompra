using Tienda.Servicios.Api.CarritoCompra.RemoteModel;

namespace Tienda.Servicios.Api.CarritoCompra.RemoteInterface
{
    public interface IAutorService
    {
        Task<(bool resultado, AutorRemote Autor, string ErrorMessage)> GetAutor(Guid? AutorId);
    }
}
