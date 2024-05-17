using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestorEventos.Servicios.Servicios
{
	public class EventoService
	{

		public IEnumerable<Evento> Eventos { get; set; }


		public EventoService()
		{
			Eventos = new List<Evento>
			{
				new Evento { IdEvento = 1 , CantidadPersonas = 5, FechaEvento = DateTime.Now, IdPersonaAgasajada = 1 , IdPersonaContacto = 2, IdTipoDespedida = 1,  NombreEvento = "Despedida de Soltero de Diego", Visible = true},
				//mockeados
				new Evento { IdEvento = 2 , CantidadPersonas = 15, FechaEvento = DateTime.Now, IdPersonaAgasajada = 3 , IdPersonaContacto = 4, IdTipoDespedida = 2, NombreEvento = "Despedida de Soltera de Juana", Visible = true},

			};


		}


		public IEnumerable<Evento> GetAllEventos()
		{
			return Eventos.Where(x=> x.Visible == true); //consulta a la base 
		}


		public Evento GetEventoPorId(int IdEvento)
		{

			var eventos = this.Eventos.Where(x => x.IdEvento == IdEvento); //consulta a la base

			if (eventos == null)
				return null;

			return eventos.First();
		}

		public bool PostNuevoEvento(Evento evento)
		{

			try
			{
				List<Evento> lista = this.Eventos.ToList();

				lista.Add(evento); /*Insert en la base*/

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}


		}


		public bool PutNuevoEvento(int idEvento, Evento evento)
		{

			try
			{
				var eventoDeLista = this.Eventos.Where(x => x.IdEvento == idEvento).First(); //LINQ

				eventoDeLista.FechaEvento = evento.FechaEvento;
				eventoDeLista.NombreEvento = evento.NombreEvento;
				eventoDeLista.CantidadPersonas = evento.CantidadPersonas;
				eventoDeLista.IdPersonaContacto = evento.IdPersonaContacto;
				eventoDeLista.IdPersonaAgasajada = evento.IdPersonaAgasajada;


				/*Update de la base*/

				/*Variable 
				 
					Nombre 
					Valor 
					Espacio en memoria 
					puntero de referencia a ese espacio en memoria 


				 */

				return true;
			}
			catch (Exception ex) 
			{ 
				return false; 
			}

		}

		/*DELETE 
		 
	--		Borrado Fisico: Eliminar directamente de la base de datos el registro haciendolo irrecuperable  

--			Borrado Lógico: Hacerle una marca al registro que lo haga "invisible" para nuestra plataforma. 

		 */

		public bool DeleteEvento (int idEvento)
		{

			/*
			 2xx = Respuestas OK 
			 3xx = Error de datos  <<- No lo usé 
			 4xx = Errores de la aplicación pero son resultados de una mala petición 
			 5xx = Errores del servidor. 
			 */
			try
			{
				var eventoAEliminar = this.Eventos.Where(x => x.IdEvento == idEvento).First();

				var listaEventos = this.Eventos.ToList();

				/*Borrado Fisico*/
				listaEventos.Remove(eventoAEliminar);


				/*Borrado Logico*/
				eventoAEliminar.Visible = false;



			//	this.Eventos.ToList().Remove(eventoAEliminar);

				//this.Eventos.ToList().Remove(x => x.idEvento == idEvento);

				return true;
			}
			
			catch(Exception ex)
			{

				return false;

			}
		}
		/*
		public void PostNuevoEventoCompleto(EventoModel eventoModel)
		{
			PersonaService personaService = new PersonaService();
			int idPersonaAgasajada = personaService.AgregarNuevaPersona(eventoModel.PersonaAgasajada);
			int idPersonaContacto = personaService.AgregarNuevaPersona(eventoModel.PersonaContacto);


			eventoModel.evento.IdPersonaAgasajada = idPersonaAgasajada;
			eventoModel.evento.IdPersonaContacto = idPersonaContacto;
			eventoModel.evento.Visible = true;

			this.PostNuevoEvento(eventoModel.evento);

			foreach(Servicio servicio in eventoModel.ListaDeServiciosContratados)
			{
				ServicioService servicioService = new ServicioService();
				servicioService.AgregarNuevoServicio(servicio);
			}



		}*/
	}
}
