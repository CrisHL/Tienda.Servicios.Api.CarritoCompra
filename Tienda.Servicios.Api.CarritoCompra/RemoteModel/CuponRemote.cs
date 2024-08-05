namespace Tienda.Servicios.Api.CarritoCompra.RemoteModel
{
    public class CuponRemote
    {
        public int CuponId { get; set; }
        public string CuponCode { get; set; }
        public double PorcentajeDescuento { get; set; }
        public int DescuentoMinimo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Categoria { get; set; }
    }
}
