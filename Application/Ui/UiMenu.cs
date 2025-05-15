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
        servicioSesion.AbrirSesion(usuario.IdUsuario);
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"\t\t-- BIENVENIDO {usuario.Nombre} --");
            Console.WriteLine("\n\t1. Interactuar\t\t2. Ver estadisticas\n\t3. Editar informacion\t4. Editar usuario/contraseña\n\t0. Cerrar sesión");
            Console.Write("\nOpción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (keyPressed.KeyChar)
            {
                case '1':
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
                    Environment.Exit(0);
                    break;
            }
        }

    }
}
