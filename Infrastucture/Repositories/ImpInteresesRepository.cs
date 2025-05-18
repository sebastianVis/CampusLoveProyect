using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;

namespace CampusLove.Infrastucture.Repositories;

public class ImpInteresesRepository : IGenericRepository<Intereses>, IInteresesRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpInteresesRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public List<Intereses> Obtener()
    {
        var InteresesList = new List<Intereses>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id_interes, nombre FROM intereses";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            InteresesList.Add(new Intereses
            {
                IdInteres = reader.GetInt32(0),
                Nombre = reader.GetString(1)
            });
        }

        return InteresesList;
    }

    public void Crear(Intereses entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO intereses(nombre) VALUES (@nombre)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre!);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Intereses entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE intereses SET nombre = @nombre WHERE id_interes = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre!);
        cmd.Parameters.AddWithValue("@id", entity.IdInteres!);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM intereses WHERE id_interes = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
    public string NombreInteres(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT i.nombre FROM usuario_interes ui INNER JOIN intereses i ON ui.id_interes = i.id_interes WHERE ui.id_usuario = @id;";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.IdUsuario);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return reader.GetString(0);
        }

        return null!;
    }
}
