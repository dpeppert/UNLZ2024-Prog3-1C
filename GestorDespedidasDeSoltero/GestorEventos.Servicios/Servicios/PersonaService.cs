using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class PersonaService
	{
		//IENumerable para esstablecer que es una Lista de Entidades
		public IEnumerable<Persona> PersonasDePrueba { get; set; }


		//constructor
		public PersonaService()
		{
			PersonasDePrueba = new List<Persona>
			{
				new Persona{ IdPersona = 1, Nombre = "Esteban", Apellido = "Gomez", Direccion = "9 de julio 2892", Email = "estebangomez@yopmail.com", Telefono = "1111111"},
				new Persona{ IdPersona = 2, Nombre = "Jose", Apellido = "Peñaloza", Direccion = "Curuzu Cuatia 12", Email = "Josepenaloza@yopmail.com", Telefono = "22222222"},
				new Persona{ IdPersona = 3, Nombre = "Juana", Apellido = "Manzo", Direccion = "Primera Junta 558", Email = "juanamanzo@yopmail.com", Telefono = "3333333"},

			};
		}

		public IEnumerable<Persona> GetPersonasDePrueba()
		{
			return PersonasDePrueba;
		}

		public Persona? GetPersonaDePruebaSegunId(int IdPersona)
		{


			try
			{
				Persona persona = PersonasDePrueba.Where(x => x.IdPersona == IdPersona).First();
				return persona; 
			}
			catch (Exception ex)
			{
				return null;
			}



		}



	}
}
