using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Factory;
using CampusLove.Application.Service;
using CampusLove.Infrastucture.PostgreSQL;
using CampusLove.Infrastucture.PostgreSQL.SQL_scripts;
using CampusLove.Domain.Entities;

namespace CampusLove.Application.Ui;

public class UiUsuario
{
    public static void MenuUsuario()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioUsuario = new UsuarioService(factory.CreateUserRepository());
        var servicioEstadisticas = new EstadisticasService(factory.CreateEstadisticasRepository());
        var interesService = new InteresService(factory.CreateInteresRepository());
        var carreraService = new CarreraService(factory.CreateCarreraRepository());
        while (true)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            string titulo = "GESTIÓN DE USUARIOS";
            int espaciosTitulo = (49 - titulo.Length) / 2;
            Console.Write($"    ║{new string(' ', espaciosTitulo)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(titulo);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{new string(' ', 49 - titulo.Length - espaciosTitulo)}║");

            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║                 CAMPUS LOVE - USUARIOS               ║");
            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ➕ Crear Nuevo Usuario                           ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("3.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ❌ Eliminar Usuario                              ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("4.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 📋 Ver Lista de Usuarios                         ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("0.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 🔙 Volver al Menú Anterior                       ║");

            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n    Selecciona una opción: ");
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (keyPressed.KeyChar)
            {
                case '1':
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

                    Console.WriteLine("Carreras disponibles: ");
                    carreraService.ObtenerCarreras();
                    Console.Write("Ingrese id de la carrera: ");
                    int idC = int.Parse(Console.ReadLine()!);
                    servicioUsuario.AddUsuarioCarrera(newUser, idC);

                    Console.WriteLine("Intereses disponibles: ");
                    interesService.ObtenerIntereses();
                    Console.Write("Ingrese id del interés: ");
                    int idI = int.Parse(Console.ReadLine()!);
                    servicioUsuario.AddUsuarioInteres(newUser, idI);

                    Console.WriteLine("\n✅ Usuario registrado correctamente.");
                    Console.WriteLine("\nPresione Enter para volver al menú.");
                    Console.ReadKey();
                    MenuUsuario();
                    return;
                case '3':
                    Console.Clear();
                    servicioUsuario.ObtenerUsuarios();
                    MenuUsuario();
                    return;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Usuarios disponibles: ");
                    servicioUsuario.ObtenerUsuarios();
                    Console.Write("Opción a Eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicioUsuario.EliminarUsuario(idE);
                    MenuUsuario();
                    return;
                case '0':
                    UiAdminMenu.MenuAdmin();
                    break;
            }
        }
    }
}
