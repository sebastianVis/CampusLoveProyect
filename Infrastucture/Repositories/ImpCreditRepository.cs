using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;

namespace CampusLove.Infrastucture.Repositories;

public class ImpCreditRepository : ICreditRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpCreditRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public void CreateCreditUser(Usuario usuario)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO registros_creditos(id_usuario, creditos_anteriores, creditos_nuevos, motivo, fecha_registro) VALUES (@idusuario, 0, 10, 'Creacion de cuenta', @fecha)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@idusuario", usuario.IdUsuario);
        cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
        cmd.ExecuteNonQuery();
    }

    public void AddCredit(Usuario usuario)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE registros_creditos SET creditos_anteriores = creditos_anteriores+creditos_nuevos, creditos_nuevos = creditos_nuevos+10, motivo = 'Agregado' WHERE id_usuario = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
        cmd.ExecuteNonQuery();
    }

    public int ObtenerCreditos(Usuario usuario)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT creditos_nuevos FROM registros_creditos WHERE id_usuario = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return reader.GetInt32(0);
        }
        return 0;
    }

    public void removeCredit(Usuario usuario)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE registros_creditos SET creditos_anteriores = creditos_anteriores+1, creditos_nuevos = creditos_nuevos-1, motivo = 'Agregado' WHERE id_usuario = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
        cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
        cmd.ExecuteNonQuery();
    }

}
