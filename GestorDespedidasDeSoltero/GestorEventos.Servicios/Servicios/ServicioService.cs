﻿
using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GestorEventos.Servicios.Servicios
{
	public class ServicioService
	{

		private string _connectionString; 

		public ServicioService ()
		{

            _connectionString = "Password=Db4dmin!;Persist Security Info=True;User ID=dbadmin;Initial Catalog=gestioneventos;Data Source=azunlz2024dbdes01.database.windows.net";

          
		}

		public IEnumerable<Servicio> GetServicios()
		{
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<Servicio> servicios = db.Query<Servicio>("SELECT * FROM Servicios WHERE Borrado = 0").ToList();

                return servicios;

            }
        }

		public Servicio GetServiciosPorId(int IdServicio)
		{
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Servicio servicio = db.Query<Servicio>("SELECT * FROM Servicios WHERE IdServicio = " + IdServicio.ToString()).FirstOrDefault();

                return servicio;
            }
        }

        public bool AgregarNuevoServicio(Servicio servicio)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Servicios (Descripcion, PrecioServicio, Borrado) VALUES ( @Descripcion, @PrecioServicio, 0)";
                db.Execute(query, servicio);
                return true;
            }
        }

        public bool ModificarServicio(int idServicio, Servicio servicio)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Servicios SET Descripcion = @Descripcion, PrecioServicio = @PrecioServicio  WHERE IdServicio = " + idServicio.ToString();
                db.Execute(query, servicio);

                return true;
            }

        }

        public bool BorrarLogicamenteServicio(int idServicio)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Servicios SET Borrado = 1 where IdServicio = " + idServicio.ToString();
                db.Execute(query);

                return true;
            }
        }

        public bool BorrarFisicamenteServicio(int idServicio)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM dbo.Servicios WHERE IdServicio = " + idServicio.ToString();
                db.Execute(query);

                return true;
            }
        }

    }
}
