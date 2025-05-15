using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;

namespace CampusLove.Infrastucture.Repositories
{
    public class ImpSesionRepository : ISesionRepository
    {
        private readonly ConexionPostgresSingleton _conexion;
        public ImpSesionRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }
        public void AbrirSesion(int id)
        {
            var connection = _conexion.ObtenerConexion();
            DateTime creacion = DateTime.Now;
            string query = "INSERT INTO sesiones_usuario(id_usuario, fecha_inicio, fecha_fin) VALUES (@id_usuario, @fecha, null)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@fecha", creacion);
            cmd.Parameters.AddWithValue("@id_usuario", id);
            cmd.ExecuteNonQuery();
        }
    }
}