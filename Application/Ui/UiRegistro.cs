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
        var servicioEstadisticas = new EstadisticasService(factory.CreateEstadisticasRepository());
        var SesionService = new SesionService(factory.CreateSesionRepository());
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

                        while (true)
                        {
                            Console.Write("\n👤 Username: ");
                            usuario.Username = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(usuario.Username) && usuario.Username.Length >= 3)
                                break;
                            Console.WriteLine("❌ El nombre de usuario debe tener al menos 3 caracteres.");
                        }

                        while (true)
                        {
                            Console.Write("\n🔒 Contraseña: ");
                            usuario.Password = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(usuario.Password) && usuario.Password.Length >= 6)
                                break;
                            Console.WriteLine("❌ La contraseña debe tener al menos 6 caracteres.");
                        }

                        while (true)
                        {
                            Console.Write("\n📛 Nombre: ");
                            usuario.Nombre = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(usuario.Nombre))
                                break;
                            Console.WriteLine("❌ El nombre no puede estar vacío.");
                        }

                        while (true)
                        {
                            Console.Write("\n🎂 Edad: ");
                            string? edadInput = Console.ReadLine();
                            if (int.TryParse(edadInput, out int edad) && edad >= 0 && edad <= 120)
                            {
                                usuario.Edad = edad;
                                break;
                            }
                            Console.WriteLine("❌ Ingrese una edad válida entre 0 y 120.");
                        }

                        Console.Write("\n💬 Frase del perfil: ");
                        usuario.FrasePerfil = Console.ReadLine()?.Trim();

                        while (true)
                        {
                            Console.Write("\n⚧️ Género:\n1. Masculino\t2. Femenino\nIngrese una opción (1 o 2): ");
                            string? generoInput = Console.ReadLine();
                            if (int.TryParse(generoInput, out int genero) && (genero == 1 || genero == 2))
                            {
                                usuario.IdGenero = genero;
                                break;
                            }
                            Console.WriteLine("❌ Selección no válida. Ingrese 1 o 2.");
                        }

                        servicioUsuario.CrearUsuario(usuario);
                        Usuario newUser = servicioUsuario.ObtenerId(usuario);
                        servicioEstadisticas.CrearEntidad(newUser);
                        Console.WriteLine("\n✅ Usuario registrado correctamente.");
                        Console.WriteLine("\nPresione Enter para volver al menú.");
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
