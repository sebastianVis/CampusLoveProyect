using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.PostgreSQL;
using Npgsql;
using Npgsql.Replication.PgOutput.Messages;

namespace CampusLove.Infrastucture.Repositories;

public class ImpEstadisticasRepository : IGenericRepository<Usuario>, IEstadisticasRepository
{
    private readonly ConexionPostgresSingleton _conexion;
    public ImpEstadisticasRepository(string connectionString)
    {
        _conexion = ConexionPostgresSingleton.Instancia(connectionString);
    }

    public void VerEstadisticas(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT likes_recibidos, dislikes_recibidos, total_matches FROM estadisticas WHERE id_usuario = @id;";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", entity.IdUsuario);
        Estadisticas estadisticas;
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            estadisticas = new Estadisticas
            {
                LikesRecibidos = reader.GetInt32(0),
                DislikesRecibidos = reader.GetInt32(1),
                TotalMatches = reader.GetInt32(2)
            };
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            // Cabecera
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            string titulo = $"ESTADÍSTICAS DE {entity.Nombre!.ToUpper()}";
            int espaciosTitulo = (49 - titulo.Length) / 2;
            Console.Write($"    ║{new string(' ', espaciosTitulo)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(titulo);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{new string(' ', 49 - titulo.Length - espaciosTitulo)}║");

            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            // Contenedor principal
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            // Sección de estadísticas
            Console.WriteLine("    ║                                                       ║");

            // Likes recibidos
            Console.Write("    ║     ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("👍 Likes recibidos: ");
            Console.ForegroundColor = ConsoleColor.White;
            string likesText = estadisticas.LikesRecibidos.ToString();
            Console.Write(likesText);
            Console.WriteLine(new string(' ', 33 - likesText.Length) + "║");

            Console.WriteLine("    ║                                                       ║");

            // Dislikes recibidos
            Console.Write("    ║     ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("👎 Dislikes recibidos: ");
            Console.ForegroundColor = ConsoleColor.White;
            string dislikesText = estadisticas.DislikesRecibidos.ToString();
            Console.Write(dislikesText);
            Console.WriteLine(new string(' ', 30 - dislikesText.Length) + "║");

            Console.WriteLine("    ║                                                       ║");

            // Total Matches
            Console.Write("    ║     ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("💘 Total Matches: ");
            Console.ForegroundColor = ConsoleColor.White;
            string matchesText = estadisticas.TotalMatches.ToString();
            Console.Write(matchesText);
            Console.WriteLine(new string(' ', 34 - matchesText.Length) + "║");
            Console.WriteLine("    ║                                                       ║");
            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");
        }
    }
    public void Crear(Usuario entity)
    {
        var connection = _conexion.ObtenerConexion();
        DateTime creacion = DateTime.Now;
        string query = "INSERT INTO estadisticas(id_usuario, likes_recibidos, dislikes_recibidos, total_matches, ultima_actualizacion) VALUES (@id_usuario, 0, 0, 0, @ultima_actualizacion)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id_usuario", entity.IdUsuario);
        cmd.Parameters.AddWithValue("@ultima_actualizacion", creacion);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarLikes(Usuario entity, int likes)
    {
        var connection = _conexion.ObtenerConexion();
        DateTime actualizacion = DateTime.Now;
        string query = "UPDATE estadisticas SET likes_recibidos = likes_recibidos + @likes_recibidos, ultima_actualizacion = @fecha WHERE id_usuario = @id_usuario";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@fecha", actualizacion);
        cmd.Parameters.AddWithValue("@likes_recibidos", likes);
        cmd.Parameters.AddWithValue("@id_usuario", entity.IdUsuario);
        cmd.ExecuteNonQuery();
    }
    public void ActualizarDislikes(Usuario entity, int dislikes)
    {
        var connection = _conexion.ObtenerConexion();
        DateTime actualizacion = DateTime.Now;
        string query = "UPDATE estadisticas SET dislikes_recibidos = dislikes_recibidos + @dislikes_recibidos, ultima_actualizacion = @fecha WHERE id_usuario = @id_usuario";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@dislikes_recibidos", dislikes);
        cmd.Parameters.AddWithValue("@id_usuario", entity.IdUsuario);
        cmd.Parameters.AddWithValue("@fecha", actualizacion);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM estadisticas WHERE id_usuario = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public bool VerificarLike(int idUsuarioActual, int idUsuarioDestino)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "SELECT COUNT(*) FROM interacciones i INNER JOIN tipo_interaccion t ON i.id_tipo_interaccion = t.id_tipo_interaccion WHERE i.id_usuario_emisor = @idOrigen AND i.id_usuario_receptor = @idDestino AND t.interaccion = 'LIKE'";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@idOrigen", idUsuarioActual);
        cmd.Parameters.AddWithValue("@idDestino", idUsuarioDestino);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        return count > 0;
    }
    public List<Usuario> Obtener()
    {
        throw new NotImplementedException();
    }
    public void Actualizar(Usuario entity)
    {
        throw new NotImplementedException();
    }
}
