using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tienda.Servicios.Api.CarritoCompra.Aplicacion;
using Tienda.Servicios.Api.CarritoCompra.Servicios;

namespace Tienda.Servicios.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public readonly ITemporalStorage _temporalStorage;

        public CarritoComprasController(IMediator mediator, ITemporalStorage temporalStorage)
        {
            _mediator = mediator;
            _temporalStorage = temporalStorage;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            await _mediator.Send(data);
            var id = _temporalStorage.ObtenerID();
            return Ok(new { Unit = Unit.Value, IDCarrito = id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoDto>> GetCarrito(int id)
        {
            return await _mediator.Send(new Consulta.Ejecuta { CarritoSessionId = id });
        }
    }
}
