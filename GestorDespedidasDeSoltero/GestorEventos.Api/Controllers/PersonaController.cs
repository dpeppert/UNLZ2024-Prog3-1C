using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonaController : Controller
	{

		[HttpGet]
		public IActionResult Get()
		{
			PersonaService personaService = new PersonaService();

			return Ok(personaService.GetPersonasDePrueba());
		}

		[HttpGet("{idPersona:int}")]
		public IActionResult GetPersonaPorId(int idPersona)
		{
			PersonaService personaService = new PersonaService();



			Persona persona = personaService.GetPersonaDePruebaSegunId(idPersona);

			if (persona == null)
				return NotFound();
			else
				return Ok(persona);
		}


		[HttpPost]
		public IActionResult PostPersona([FromBody] Persona persona)
		{
			PersonaService personaService = new PersonaService();

			personaService.AgregarNuevaPersona(persona);

			return Ok();
		}

		[HttpPut("{idPersona:int}")]
		public IActionResult PutPersona(int idPersona, [FromBody] Persona persona)
		{
			PersonaService personaService = new PersonaService();

			personaService.ModificarPersona(idPersona, persona);

			return Ok();

		}

		[HttpPatch("borradologico/{idPersona:int}")]
		public IActionResult BorradoLogicoPersona(int idPersona)
		{
			PersonaService personaService = new PersonaService();

			personaService.BorrarLogicamentePersona(idPersona);

			return Ok();
		}

		[HttpDelete("{idPersona:int}")]
		public IActionResult BorradoFisico(int idPersona)
		{
			PersonaService personaService = new PersonaService();
			personaService.BorrarFisicamentePersona(idPersona);

			return Ok();
		}


	}
}
