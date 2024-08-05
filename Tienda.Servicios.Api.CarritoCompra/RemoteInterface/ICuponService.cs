using Tienda.Servicios.Api.CarritoCompra.RemoteModel;

namespace Tienda.Servicios.Api.CarritoCompra.RemoteInterface
{
    public interface ICuponService
    {
        Task<(bool resultado, CuponRemote Autor, string ErrorMessage)> GetCupon(string code);
    }
}
