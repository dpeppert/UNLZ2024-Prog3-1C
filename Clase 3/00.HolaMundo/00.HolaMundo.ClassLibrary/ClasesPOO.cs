namespace _00.HolaMundo.ClassLibrary
{

	public class Auditora { 
		private int IdUsuarioAlta { get; set; }
		private DateTime FechaAlta { get; set; }

		public void SetDatosAuditoria (int IdUsuario)
		{
			this.IdUsuarioAlta = IdUsuario;
			this.FechaAlta = DateTime.Now;
		}
	}

							//Herencia
	public class Eventos: Auditora
	{
		public Eventos()
		{
			this.SetDatosAuditoria(45);
		}

		public DateTime FechaEvento { get; set; }
		public string? NombreEvento { get; set; }
		public  int CantidadHoras { get; set; }
		public int CantidadPersonas { get; set; }

		private int IdTipoEvento { get; set; } 

		public void NuevoEventoParaElDiaDeHoy()
		{
			this.NombreEvento = "NuevoGenerico";
			this.FechaEvento = DateTime.Now;
			this.CantidadHoras = 1;
			this.CantidadPersonas = 4;
		}

		public void SetTipoEvento(int IdtipoEvento)
		{
			this.IdTipoEvento = IdtipoEvento;
		}

		//ejemplo de polimorfismo 
		public void NuevoEventoParaElDiaDeHoy(int CantidadPersonas)
		{
			if (CantidadPersonas > 5)
			{
				this.NombreEvento = "Evento Grande";
				this.FechaEvento = DateTime.Now.AddDays(7);
				this.CantidadHoras = 1;
				this.CantidadPersonas = CantidadPersonas;
			}
			else
			{
				this.NombreEvento = "Evento Normal";
				this.FechaEvento = DateTime.Now;
				this.CantidadHoras = 1;
				this.CantidadPersonas = CantidadPersonas;
			}

			
		}


	}

 
}
