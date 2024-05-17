using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicioController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetServicios()
		{
			ServicioService serviciosService = new ServicioService();

			return Ok(serviciosService.GetServicios());
		}

		[HttpGet("{idServicio:int}")]
		public IActionResult GetServicioPorId(int idServicio)
		{
			ServicioService serviciosService = new ServicioService();

			var servicio = serviciosService.GetServiciosPorId(idServicio);

			if (servicio == null)
				return NotFound();
			else
				return Ok(servicio);
		}

		[HttpPost("nuevo")]
		public IActionResult PostNuevoServicio([FromBody] Servicio servicionuevo)
		{

			ServicioService serviciosService = new ServicioService();
			serviciosService.AgregarNuevoServicio(servicionuevo);

			return Ok();
		}



	}
}
