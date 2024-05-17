using Dapper;
using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorEventos.Servicios.Servicios
{
	public class PersonaService
	{
		//IENumerable para esstablecer que es una Lista de Entidades
		//public IEnumerable<Persona> PersonasDePrueba { get; set; }

		private string _connectionString; 

		//constructor
		public PersonaService()
		{

			//Connection string 
			_connectionString = "Password=Db4dmin!;Persist Security Info=True;User ID=dbadmin;Initial Catalog=gestioneventos;Data Source=azunlz2024dbdes01.database.windows.net";
								//"Password=Db4dmin!;Persist Security Info=True;User ID=dbadmin;Initial Catalog=gestioneventos;Data Source=azunlz2024dbdes01.database.windows.net​";
			/*PersonasDePrueba = new List<Persona>
			{
				new Persona{ IdPersona = 1, Nombre = "Esteban", Apellido = "Gomez", Direccion = "9 de julio 2892", Email = "estebangomez@yopmail.com", Telefono = "1111111"},
				new Persona{ IdPersona = 2, Nombre = "Jose", Apellido = "Peñaloza", Direccion = "Curuzu Cuatia 12", Email = "Josepenaloza@yopmail.com", Telefono = "22222222"},
				new Persona{ IdPersona = 3, Nombre = "Juana", Apellido = "Manzo", Direccion = "Primera Junta 558", Email = "juanamanzo@yopmail.com", Telefono = "3333333"},

			};*/



		}

		public IEnumerable<Persona> GetPersonasDePrueba()
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				List<Persona> personas = db.Query<Persona>("SELECT * FROM Personas WHERE Borrado = 0").ToList();

				return personas;

			}

//			return PersonasDePrueba;
		}

		public Persona? GetPersonaDePruebaSegunId(int IdPersona)
		{

			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				Persona persona = db.Query<Persona>("SELECT * FROM Personas WHERE IdPersona = " + IdPersona.ToString()).FirstOrDefault();

				return persona;
			}

/*
			try
			{
				Persona persona = PersonasDePrueba.Where(x => x.IdPersona == IdPersona).First();
				return persona; 
			}
			catch (Exception ex)
			{
				return null;
			}

			*/

		}

		public int AgregarNuevaPersona (Persona persona)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				string query = "INSERT INTO Personas (Nombre, Apellido, Direccion, Telefono, Email) VALUES ( @Nombre, @Apellido, @Direccion, @Telefono, @Email); SELECT Inserted.IdPersona";
				db.Execute(query, persona);


				return persona.IdPersona;
			}
		}

		public bool ModificarPersona(int idPersona, Persona persona)
		{

			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				string query = "UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono, Email = @Email  WHERE IdPersona = " + idPersona.ToString();
				db.Execute(query, persona);

				return true;
			}

		}

		public bool BorrarLogicamentePersona (int idPersona )
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				string query = "UPDATE Personas SET Borrado = 1 where IdPersona = " + idPersona.ToString();
				db.Execute(query);

				return true;
			}
		}

		public bool BorrarFisicamentePersona(int idPersona)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				string query = "DELETE FROM dbo.Personas WHERE IdPersona = " + idPersona.ToString();
				db.Execute(query);

				return true;
			}
		}
	}
}
