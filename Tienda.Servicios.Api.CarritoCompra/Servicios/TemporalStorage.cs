namespace Tienda.Servicios.Api.CarritoCompra.Servicios
{
    public class TemporalStorage: ITemporalStorage
    {
        private int _id;

        public void AlmacenarId(int id)
        {
            _id = id;
        }

        public int ObtenerID()
        {
            return _id;
        }
    }
}
