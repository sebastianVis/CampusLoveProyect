using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;

namespace CampusLove.Infrastucture.Repositories
{
    public class ImpMatchRepository : IMatchRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpMatchRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }
        public void CreateMatch(Usuario usuarioUno, Usuario usuarioDos)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO matches(id_usuario_uno, id_usuario_dos, fecha_match) VALUES (@idusuariouno, @idusuariodos, @fecha)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idusuariouno", usuarioUno.IdUsuario!);
            cmd.Parameters.AddWithValue("@idusuariodos", usuarioDos.IdUsuario!);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
    }
}