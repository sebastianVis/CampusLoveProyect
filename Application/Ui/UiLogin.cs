using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Application.Service;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Factory;
using CampusLove.Infrastucture.PostgreSQL;
using CampusLove.Infrastucture.PostgreSQL.SQL_scripts;

namespace CampusLove.Application.Ui;
public class UiLogin
{
    public static void MenuLogin()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioUsuario = new UsuarioService(factory.CreateUserRepository());

        while (true)
        {
            var usuario = SolicitarCredenciales();

            if (servicioUsuario.ObtenerLogin(usuario))
            {
                Console.WriteLine("\n✅ Inicio de sesión exitoso.");
                break;
            }
            else
            {
                Console.WriteLine("\n❌ Usuario o contraseña incorrectos. Intente nuevamente.\n");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
    }

    private static Usuario SolicitarCredenciales()
    {
        var usuario = new Usuario();

        Console.WriteLine("\n-- Iniciar sesión --\n");

        Console.Write("Nombre de usuario: ");
        usuario.Username = Console.ReadLine();

        Console.Write("Contraseña: ");
        usuario.Password = Console.ReadLine();

        return usuario;
    }
}
