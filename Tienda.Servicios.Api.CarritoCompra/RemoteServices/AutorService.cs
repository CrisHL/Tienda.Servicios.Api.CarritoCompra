using System.Text.Json;
using Tienda.Servicios.Api.CarritoCompra.RemoteInterface;
using Tienda.Servicios.Api.CarritoCompra.RemoteModel;
namespace Tienda.Servicios.Api.CarritoCompra.RemoteServices
{
    public class AutorService : IAutorService
    {
        private readonly IHttpClientFactory httpClient;
        private readonly ILogger<AutorService> logger;

        public AutorService(IHttpClientFactory _httpClient, ILogger<AutorService> _logger)
        {
            httpClient = _httpClient;
            logger = _logger;
        }

        public async Task<(bool resultado, AutorRemote Autor, string ErrorMessage)> GetAutor(Guid? AutorId)
        {
            try
            {
                //creamos nuestro objeto que se comunicara con nuestro endpoint libros
                var cliente = httpClient.CreateClient("Autores");
                //nos comunicamos con nuestro endpoint que estamos solicitando
                var response = await cliente.GetAsync($"api/Autor/{AutorId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    //espicificamos que no hay problema por la estructura del json como venga, mayusculas o minusculas
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<AutorRemote>(contenido, options);
                    return (true, resultado, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

    }
}
