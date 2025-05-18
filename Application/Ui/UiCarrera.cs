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

public class UiCarrera
{
    public static void MenuCarrera()
    {
        IDbFactory factory = new PostgresDbFactory(DbParameters.Parameters);
        var servicioCarrera = new CarreraService(factory.CreateCarreraRepository());
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
            Console.WriteLine("    ║                 CAMPUS LOVE - ACADÉMICO               ║");
            Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ➕ Crear Nueva Carrera                           ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("2.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ✏️  Editar Carrera Existente                      ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("3.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ❌ Eliminar Carrera                              ║");

            Console.WriteLine("    ║                                                       ║");

            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("4.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" 📋 Ver Lista de Carreras                         ║");

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
                    Carrera carrera = new Carrera();
                    Console.WriteLine("Nombre de la nueva carrera: ");
                    carrera.Nombre = Console.ReadLine();
                    servicioCarrera.CrearCarrera(carrera);
                    MenuCarrera();
                    return;
                case '2':
                    Console.Clear();
                    Carrera actualizar = new Carrera();
                    Console.WriteLine("Carreras disponibles: ");
                    servicioCarrera.ObtenerCarreras();
                    Console.Write("Opción a actualizar: ");
                    actualizar.IdCarrera = int.Parse(Console.ReadLine()!);
                    Console.Write("\nNuevo nombre: ");
                    actualizar.Nombre = Console.ReadLine();
                    servicioCarrera.EditarCarrera(actualizar);
                    MenuCarrera();
                    return;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Carreras disponibles: ");
                    servicioCarrera.ObtenerCarreras();
                    Console.Write("Opción a Eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicioCarrera.EliminarCarrera(idE);
                    MenuCarrera();
                    return;
                case '4':
                    servicioCarrera.ObtenerCarreras();
                    Console.WriteLine("Escriba cualquier tecla para continuar.");
                    Console.ReadKey();
                    MenuCarrera();
                    return;
                case '0':
                    UiAdminMenu.MenuAdmin();
                    break;
            }
        }
    }

}
