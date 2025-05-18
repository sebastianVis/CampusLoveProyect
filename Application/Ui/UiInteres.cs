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

public class UiInteres
{
    public static void MenuInteres()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioInteres = new InteresService(factory.CreateInteresRepository());
        while (true)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            string titulo = "GESTIÓN DE CARRERAS";
            int espaciosTitulo = (49 - titulo.Length) / 2;
            Console.Write($"    ║{new string(' ', espaciosTitulo)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(titulo);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{new string(' ', 49 - titulo.Length - espaciosTitulo)}║");

            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║                 CAMPUS LOVE - INTERES               ║");
            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ➕ Crear Nuevo Interes                           ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("2.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ✏️  Editar Interes Existente                      ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("3.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ❌ Eliminar Interes                              ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("4.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 📋 Ver Lista de Intereses                         ║");

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
                    Intereses interes = new Intereses();
                    Console.WriteLine("Nombre del nuevo interes: ");
                    interes.Nombre = Console.ReadLine();
                    servicioInteres.CrearIntereses(interes);
                    MenuInteres();
                    return;
                case '2':
                    Console.Clear();
                    Intereses actualizar = new Intereses();
                    Console.WriteLine("Intereses disponibles: ");
                    servicioInteres.ObtenerIntereses();
                    Console.Write("Opción a actualizar: ");
                    actualizar.IdInteres = int.Parse(Console.ReadLine()!);
                    Console.Write("\nNuevo nombre: ");
                    actualizar.Nombre = Console.ReadLine();
                    servicioInteres.EditarIntereses(actualizar);
                    MenuInteres();
                    return;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Intereses disponibles: ");
                    servicioInteres.ObtenerIntereses();
                    Console.Write("Opción a Eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicioInteres.EliminarIntereses(idE);
                    MenuInteres();
                    return;
                case '4':
                    servicioInteres.ObtenerIntereses();
                    Console.WriteLine("Escriba cualquier tecla para continuar.");
                    Console.ReadKey();
                    MenuInteres();
                    return;
                case '0':
                    UiAdminMenu.MenuAdmin();
                    break;
            }
        }
    }
}