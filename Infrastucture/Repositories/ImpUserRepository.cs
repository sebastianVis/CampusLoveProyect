using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;
using Npgsql.Replication.PgOutput.Messages;

namespace CampusLove.Infrastucture.Repositories;

public class ImpUserRepository : IGenericRepository<Usuario>, IUserRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpUserRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public void Crear(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "BEGIN; INSERT INTO login(username, password) VALUES(@username, @password); INSERT INTO usuarios(nombre, edad, frase_perfil, id_genero) VALUES (@nombre, @edad, @frase_perfil, @id_genero); COMMIT;";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@username", entity.Username!);
        cmd.Parameters.AddWithValue("@password", entity.Password!);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre!);
        cmd.Parameters.AddWithValue("@edad", entity.Edad!);
        cmd.Parameters.AddWithValue("@frase_perfil", entity.FrasePerfil!);
        cmd.Parameters.AddWithValue("@id_genero", entity.IdGenero!);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE usuarios SET nombre = @nombre, edad = @edad, frase_perfil = @frase_perfil WHERE id_usuario = @id;";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.IdUsuario!);
        cmd.Parameters.AddWithValue("@nombre", entity.Nombre!);
        cmd.Parameters.AddWithValue("@edad", entity.Edad!);
        cmd.Parameters.AddWithValue("@frase_perfil", entity.FrasePerfil!);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarLogin(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE login SET username = @username, password = @password WHERE id_usuario = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.IdUsuario!);
        cmd.Parameters.AddWithValue("@username", entity.Username!);
        cmd.Parameters.AddWithValue("@password", entity.Password!);
        cmd.ExecuteNonQuery();
    }
    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "BEGIN; DELETE FROM login WHERE id_usuario = @id; DELETE FROM usuarios WHERE id_usuario = @id COMMIT;";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
    public bool ObtenerLogin(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT * FROM login WHERE username = @username AND password = @password";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@username", entity.Username!);
        cmd.Parameters.AddWithValue("@password", entity.Password!);
        using var reader = cmd.ExecuteReader();
        return reader.Read();
    }

    public List<Usuario> Obtener()
    {
        var UsuarioList = new List<Usuario>();
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT id_usuario, nombre, edad, frase_perfil, id_genero FROM usuarios";
        using var cmd = new NpgsqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            UsuarioList.Add(new Usuario
            {
                IdUsuario = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Edad = reader.GetInt32(2),
                FrasePerfil = reader.GetString(3),
            });
        }
        return UsuarioList;
    }

    public Usuario ObtenerId(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT u.id_usuario, u.nombre, u.edad FROM login l INNER JOIN usuarios u ON l.id_usuario = u.id_usuario WHERE username = @username AND password = @password;";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@username", entity.Username!);
        cmd.Parameters.AddWithValue("@password", entity.Password!);

        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            var usuario = new Usuario
            {
                IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                Edad = reader.GetInt32(reader.GetOrdinal("edad")),
            };

            return usuario;
        }
        return null!;
    }
}

