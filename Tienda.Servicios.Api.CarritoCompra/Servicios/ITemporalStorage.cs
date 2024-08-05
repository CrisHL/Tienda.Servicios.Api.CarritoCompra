namespace Tienda.Servicios.Api.CarritoCompra.Servicios
{
    public interface ITemporalStorage
    {
        void AlmacenarId(int id);
        int ObtenerID();
    }
}
