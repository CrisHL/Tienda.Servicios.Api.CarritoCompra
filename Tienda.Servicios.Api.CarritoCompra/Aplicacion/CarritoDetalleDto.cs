namespace Tienda.Servicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDetalleDto
    {
        public Guid? LibroId { get; set; }
        public string TituloLibro { get; set; }
        public string Image {  get; set; }
        public double Precio { get; set; }
        public double IVA { get; set; }
        public string AutorLibro { get; set; }
        public DateTime? FechaPublicacion { get; set; }

    }
}
