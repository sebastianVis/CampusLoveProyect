using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;

namespace CampusLove.Infrastucture.Repositories;

public class ImpCarreraRepository : IGenericRepository<Carrera>, ICarreraRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpCarreraRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public List<Carrera> Obtener()
    {
        var CarreraList = new List<Carrera>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id_carrera, nombre FROM carrera";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            CarreraList.Add(new Carrera
            {
                IdCarrera = reader.GetInt32(0),
                Nombre = reader.GetString(1)
            });
        }

        return CarreraList;
    }

    public void Crear(Carrera entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO carrera(nombre) VALUES (@nombre)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre!);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Carrera entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE FROM carrera SET nombre = @nombre WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre!);
        cmd.Parameters.AddWithValue("@id", entity.IdCarrera!);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM carrera WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public void AgregarCarrera(Usuario usuario, int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO usuario_carrera(id_carrera, id_usuario) VALUES (@id, @idusuario)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@idusuario", usuario.IdUsuario!);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
