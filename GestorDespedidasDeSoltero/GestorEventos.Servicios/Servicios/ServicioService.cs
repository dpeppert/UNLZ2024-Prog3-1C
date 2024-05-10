
using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class ServicioService
	{
		public IEnumerable<Servicio> Servicios { get; set; }

		public ServicioService ()
		{
			this.Servicios = new List<Servicio>
			{
				new Servicio{ IdServicio = 1, Descripcion = "Bar Hopping", PrecioServicio = 25000 },
				new Servicio{ IdServicio = 2, Descripcion = "Servicio de Transporte", PrecioServicio = 20000 },
				new Servicio{ IdServicio = 3, Descripcion = "Entradas de Boliches Incluidas", PrecioServicio = 10000 }
			};
		}

		public IEnumerable<Servicio> GetServicios()
		{
			return this.Servicios;
		}

		public Servicio GetServiciosPorId(int IdServicio)
		{
			var servicios = Servicios.Where(x => x.IdServicio == IdServicio);

			if (servicios == null)
				return null;

			return servicios.First();
		}


		public bool AgregarServicio(Servicio servicio )
		{
			try
			{
				List<Servicio> lista = this.Servicios.ToList();
				lista.Add(servicio);
//				this.Servicios.ToList().Add(servicio);
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}


		}

	}
}
