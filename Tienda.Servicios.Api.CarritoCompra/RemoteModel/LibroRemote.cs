namespace Tienda.Servicios.Api.CarritoCompra.RemoteModel
{
    public class LibroRemote
    {
        public Guid? LibreriaMaterialId { get; set; }
        public string Titulo { get; set; }
        public string Image {  get; set; }
        public double Precio { get; set; }
        public double IVA { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }
    }
}
