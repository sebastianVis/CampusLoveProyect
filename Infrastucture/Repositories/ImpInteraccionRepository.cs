using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;

namespace CampusLove.Infrastucture.Repositories;

public class ImpInteraccionRepository : IInteraccionRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpInteraccionRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }
    public void CrearInteraccion(Usuario usuarioUno, Usuario usuarioDos, int idInteraccion)
    {
        var connection = _conexion.ObtenerConexion();
        DateTime creacion = DateTime.Now;
        string query = "INSERT INTO interacciones(id_usuario_emisor, id_usuario_receptor, id_tipo_interaccion, fecha_interaccion) VALUES (@idusuarioemisor, @idusuarioreceptor, @idtipointeraccion, @fecha)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@idusuarioemisor", usuarioUno.IdUsuario);
        cmd.Parameters.AddWithValue("@idusuarioreceptor", usuarioDos.IdUsuario);
        cmd.Parameters.AddWithValue("@idtipointeraccion", idInteraccion);
        cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
        cmd.ExecuteNonQuery();
    }

    public void EliminarInteraccion(Usuario usuarioUno)
    {
        var connection = _conexion.ObtenerConexion();
        DateTime creacion = DateTime.Now;
        string query = "DELETE FROM interacciones WHERE id_usuario_emisor = @idusuario";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@idusuario", usuarioUno.IdUsuario);
        cmd.ExecuteNonQuery();
    }
}
