using _00.HolaMundo.ClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.WebApi.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class EventosController : Controller
	{
		[HttpGet("ConsultarEventos")]
		public IActionResult Get()
		{
			Eventos evento = new Eventos();
			evento.CantidadHoras = 12;
			evento.CantidadPersonas = 28; 
			evento.FechaEvento = DateTime.Now.AddDays(9);
			 
			evento.NombreEvento = "Despedida de Soltero de Casemiro";

			return Ok(evento);


		}

		[HttpGet("ConsultarEventoPorPolimorfismo/{cantidadPersonas:int}")]
		public IActionResult GetEventoParaPolimorfismo(int cantidadPersonas)
		{
			List<Eventos> eventos = new List<Eventos>();

			Eventos evento = new Eventos();
			evento.NuevoEventoParaElDiaDeHoy();
			evento.SetTipoEvento(1);

			eventos.Add(evento);

			Eventos segundoEvento = new Eventos();
			segundoEvento.NuevoEventoParaElDiaDeHoy(cantidadPersonas);

			eventos.Add(evento);

			return Ok(eventos);

		}



	}
}
