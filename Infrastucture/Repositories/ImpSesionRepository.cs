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

        public void CerrarSesion(int id)
        {
            var connection = _conexion.ObtenerConexion();
            DateTime cierre = DateTime.Now;
            string query = "UPDATE sesiones_usuario SET fecha_fin = @fecha WHERE id_sesion = ( SELECT id_sesion FROM sesiones_usuario WHERE id_usuario = @id_usuario AND fecha_fin IS NULL ORDER BY fecha_inicio DESC LIMIT 1);";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@fecha", cierre);
            cmd.Parameters.AddWithValue("@id_usuario", id);
            cmd.ExecuteNonQuery();
        }
    }
}