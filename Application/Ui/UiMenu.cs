using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Application.Service;
using CampusLove.Domain.Factory;
using CampusLove.Infrastucture.PostgreSQL;
using CampusLove.Infrastucture.PostgreSQL.SQL_scripts;

namespace CampusLove.Application.Ui;

public class UiMenu
{
    public static void MenuStart(Usuario usuario)
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioEstadisticas = new EstadisticasService(factory.CreateEstadisticasRepository());
        var servicioSesion = new SesionService(factory.CreateSesionRepository());
        var servicioUsuario = new UsuarioService(factory.CreateUserRepository());
        var servicioMatch = new MatchService(factory.CreateMatchRepository());
        var servicioInteracciones = new InteraccionService(factory.CreateInteraccionRepository());
        var interesService = new InteresService(factory.CreateInteresRepository());
        var carreraService = new CarreraService(factory.CreateCarreraRepository());
        var creditosService = new CreditosService(factory.CreateCreditRepository());

        servicioSesion.AbrirSesion(usuario.IdUsuario);
        while (true)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            // Cabecera más pequeña
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            string bienvenida = $"¡BIENVENIDO/A {usuario.Nombre!.ToUpper()}!";
            int espaciosBienvenida = (49 - bienvenida.Length) / 2;
            Console.Write($"    ║{new string(' ', espaciosBienvenida)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(bienvenida);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{new string(' ', 49 - bienvenida.Length - espaciosBienvenida)}║");

            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            // Logo compacto de Campus Love
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║            CAMPUS LOVE - MENU PRINCIPAL               ║");
            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            // Menú principal más compacto
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            // Opciones en una columna para mayor compacidad
            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Interactuar con Usuarios                         ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("2.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Ver mis Estadísticas                             ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("3.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Editar mi Información                            ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("4.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Cambiar Usuario/Contraseña                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Cerrar Sesión                                    ║");

            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            // Información del usuario en formato compacto
            string Newgenero = usuario.IdGenero == 1 ? "Masculino" : "Femenino";

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n    Perfil: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{usuario.Edad} años, ");
            Console.Write($"{Newgenero}");

            if (!string.IsNullOrEmpty(usuario.FrasePerfil))
            {
                // Recortar la frase si es muy larga
                string frase = usuario.FrasePerfil.Length > 40
                    ? usuario.FrasePerfil.Substring(0, 37) + "..."
                    : usuario.FrasePerfil;
                Console.WriteLine($"\n    \"{frase}\"");
            }

            // Solicitud de opción (sin animación para mayor velocidad)
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n    Selecciona una opción: ");
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (keyPressed.KeyChar)
            {
                case '1':
                    List<Usuario> usuarios = servicioUsuario.ObtenerUsuariosTinder();

                    if (creditosService.ObtenerCreditos(usuario) <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("¡No tienes créditos disponibles para continuar!");
                        Console.WriteLine("Adquiere más créditos para seguir interactuando.");
                        Console.WriteLine("Presiona cualquier tecla para volver al menú principal...");
                        Console.ReadKey();
                        return;
                    }

                    int indiceActual = 0;
                    bool salir = false;
                    while (!salir && indiceActual < usuarios.Count)
                    {
                        Console.Clear();
                        var usuarioActual = usuarios[indiceActual];

                        string genero = "";
                        switch (usuarioActual.IdGenero)
                        {
                            case 1:
                                genero = "Masculino";
                                break;
                            case 2:
                                genero = "Femenino";
                                break;
                        }
                        if (usuarioActual.IdUsuario == usuario.IdUsuario)
                        {
                            indiceActual++;
                            if (indiceActual >= usuarios.Count)
                            {
                                Console.Clear();
                                Console.WriteLine("¡Has visto todos los perfiles disponibles!");
                                Console.WriteLine("Presiona cualquier tecla para volver al menú principal...");
                                Console.ReadKey();
                                salir = true;
                            }
                            continue; // Salta a la siguiente iteración del bucle
                        }
                        else
                        {
                            bool yaDioLike = servicioEstadisticas.VerificarLike(usuario.IdUsuario, usuarioActual.IdUsuario);
                            string estadoLike = yaDioLike ? "❤️ Ya le diste like" : "";
                            Console.WriteLine("╔══════════════════════════════════════╗");
                            Console.WriteLine($"║ ID: {usuarioActual.IdUsuario}                             ║");
                            Console.WriteLine($"║ {usuarioActual.Nombre}, {usuarioActual.Edad}                          ║");
                            Console.WriteLine($"║ Género: {genero}                         ║");
                            Console.WriteLine("╠══════════════════════════════════════╣");
                            Console.WriteLine($"║ {usuarioActual.FrasePerfil!.PadRight(38)}║");
                            Console.WriteLine("╚══════════════════════════════════════╝");
                            Console.WriteLine("╠══════════════════════════════════════╣");
                            Console.WriteLine($"║ Interes: {interesService.NombreInteres(usuarioActual)!.PadRight(38)}║");
                            Console.WriteLine("╚══════════════════════════════════════╝");
                            Console.WriteLine("╠══════════════════════════════════════╣");
                            Console.WriteLine($"║ Carrera: {carreraService.NombreCarrera(usuarioActual)!.PadRight(38)}║");
                            Console.WriteLine("╚══════════════════════════════════════╝");
                            Console.WriteLine(estadoLike);

                            Console.WriteLine("\nOpciones:");

                            if (yaDioLike)
                            {
                                Console.WriteLine("1 - Ya diste like (no disponible)");
                            }
                            else
                            {
                                Console.WriteLine("1 - Me gusta (Like)");
                            }
                            Console.WriteLine("2 - No me gusta (Dislike)");
                            Console.WriteLine("0 - Salir");
                            Console.Write("\nTu elección: ");

                            ConsoleKeyInfo input = Console.ReadKey();

                            switch (input.KeyChar)
                            {
                                case '1':
                                    if (!yaDioLike)
                                    {
                                        // Actualizar contador de likes
                                        servicioEstadisticas.ActualizarLikes(usuarioActual, 1);

                                        // Registrar interacción
                                        servicioInteracciones.CrearInteraccion(usuario, usuarioActual, 1);

                                        Console.WriteLine("¡Has dado like!");
                                        creditosService.QuitarCreditos(usuario);

                                        // Verificar si hay match
                                        if (servicioEstadisticas.VerificarLike(usuarioActual.IdUsuario, usuario.IdUsuario))
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("¡ES UN MATCH! 🎉");
                                            Console.WriteLine("¡Has hecho match con " + usuarioActual.Nombre + "!");
                                            servicioMatch.CreateMatch(usuario, usuarioActual);
                                            Thread.Sleep(3000);
                                        }

                                    }
                                    indiceActual++;
                                    break;
                                case '2':
                                    servicioEstadisticas.ActualizarDislikes(usuarioActual, 1);
                                    servicioInteracciones.CrearInteraccion(usuario, usuarioActual, 2);
                                    Console.WriteLine("Has dado dislike");
                                    creditosService.QuitarCreditos(usuario);
                                    Thread.Sleep(1000);
                                    indiceActual++;
                                    break;
                                case '0':
                                    salir = true;
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                                    Thread.Sleep(1000);
                                    break;
                            }

                            if (indiceActual >= usuarios.Count && !salir)
                            {
                                Console.Clear();
                                Console.WriteLine("¡Has visto todos los perfiles disponibles!");
                                Console.WriteLine("Presiona cualquier tecla para volver al menú principal...");
                                Console.ReadKey();
                                salir = true;
                            }
                        }
                    }
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine($"\t\t-- ESTADISTICAS DE {usuario.Nombre} --");
                    servicioEstadisticas.VerEstadisticas(usuario);
                    Console.WriteLine("Presione Enter para volver al menú.");
                    Console.ReadKey();
                    break;
                case '3':
                    Usuario newUser = new Usuario();
                    Console.Clear();
                    newUser.IdUsuario = usuario.IdUsuario;
                    Console.Write("Escriba nuevo nombre: ");
                    newUser.Nombre = Console.ReadLine();
                    Console.Write("Escriba nueva edad: ");
                    newUser.Edad = int.Parse(Console.ReadLine()!);
                    Console.Write("Escriba nuevo texto del perfil: ");
                    newUser.FrasePerfil = Console.ReadLine();
                    servicioUsuario.EditarUsuario(newUser);
                    Console.WriteLine("Presione Enter para volver a iniciar sesion.");
                    Console.ReadKey();
                    servicioSesion.CerrarSesion(usuario.IdUsuario);
                    UiMainMenu.MainMenu();
                    break;
                case '4':
                    Usuario userNew = new Usuario();
                    userNew.IdUsuario = usuario.IdUsuario;
                    Console.Write("Escriba nuevo username: ");
                    userNew.Username = Console.ReadLine();
                    Console.Write("Escriba nueva contraseña: ");
                    userNew.Password = Console.ReadLine();
                    Console.WriteLine("Presione Enter para volver a iniciar sesion.");
                    Console.ReadKey();
                    servicioSesion.CerrarSesion(usuario.IdUsuario);
                    UiMainMenu.MainMenu();
                    break;
                case '0':
                    servicioSesion.CerrarSesion(usuario.IdUsuario);
                    UiMainMenu.MainMenu();
                    break;
            }
        }

    }


}
