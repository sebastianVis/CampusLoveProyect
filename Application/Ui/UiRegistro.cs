using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Application.Service;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Factory;
using CampusLove.Infrastucture.PostgreSQL;
using CampusLove.Infrastucture.PostgreSQL.SQL_scripts;

namespace CampusLove.Application.Ui;
public class UiRegistro
{
    public static void MenuRegistro()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioUsuario = new UsuarioService(factory.CreateUserRepository());
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n-- Registrar Usuario --\n\n");
            Console.WriteLine("\t1. Ver Usuarios\n\t2. Registrar usuario\n\t0. Salir");
            Console.Write("\nOpción: ");
            while (true)
            {
                ConsoleKeyInfo KeyPressed = Console.ReadKey();
                switch (KeyPressed.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        servicioUsuario.ObtenerUsuarios();
                        Console.WriteLine("Presione Enter para volver al menú.");
                        Console.ReadKey();
                        return;
                    case '2':
                        Console.Clear();
                        Usuario usuario = new Usuario();
                        Console.Write("\nUsername: ");
                        usuario.Username = Console.ReadLine();
                        Console.Write("\nContraseña: ");
                        usuario.Password = Console.ReadLine();
                        Console.Write("\nNombre: ");
                        usuario.Nombre = Console.ReadLine();
                        Console.Write("\nEdad: ");
                        usuario.Edad = int.Parse(Console.ReadLine()!);
                        Console.Write("\nFrase del perfil: ");
                        usuario.FrasePerfil = Console.ReadLine();
                        Console.Write("\nGeneros:\n1. Masculino\t2. Femenino\nIngrese genero: ");
                        usuario.IdGenero = int.Parse(Console.ReadLine()!);
                        servicioUsuario.CrearUsuario(usuario);
                        Console.WriteLine("Presione Enter para volver al menú.");
                        Console.ReadKey();
                        return;
                    case '0':
                        return;

                    default:
                        Console.WriteLine("❌ Opción no válida.");
                        return;
                }
            }
        }

    }
}
