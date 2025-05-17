using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Application.Ui;

public class UiMainMenu
{
    public static void MainMenu()
    {
        while (true)
        {
    {
        Console.Clear();
        // Configura el color de fondo y texto para mejor apariencia
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine(@"
    ╔═══════════════════════════════════════════════════════════════════════╗
    ║                                                                       ║
    ║     ██████╗ █████╗ ███╗   ███╗██████╗ ██╗   ██╗███████╗               ║
    ║    ██╔════╝██╔══██╗████╗ ████║██╔══██╗██║   ██║██╔════╝               ║
    ║    ██║     ███████║██╔████╔██║██████╔╝██║   ██║███████╗               ║
    ║    ██║     ██╔══██║██║╚██╔╝██║██╔═══╝ ██║   ██║╚════██║               ║
    ║    ╚██████╗██║  ██║██║ ╚═╝ ██║██║     ╚██████╔╝███████║               ║
    ║     ╚═════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝      ╚═════╝ ╚══════╝               ║
    ║                                                                       ║
    ║        ██╗      ██████╗ ██╗   ██╗███████╗                            ║
    ║        ██║     ██╔═══██╗██║   ██║██╔════╝                            ║
    ║        ██║     ██║   ██║██║   ██║█████╗                              ║
    ║        ██║     ██║   ██║╚██╗ ██╔╝██╔══╝                              ║
    ║        ███████╗╚██████╔╝ ╚████╔╝ ███████╗                            ║
    ║        ╚══════╝ ╚═════╝   ╚═══╝  ╚══════╝                            ║
    ║                                                                       ║
    ╚═══════════════════════════════════════════════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\t♥ Encuentra tu pareja ideal en Campuslands ♥\n");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("    ╔═══════════════════════════════════════════════════════════════╗");

        Console.Write("    ║  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("1.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Iniciar sesión                                         ║");

        Console.Write("    ║  ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("2.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Registrar nuevo usuario                                ║");

        Console.Write("    ║  ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("3.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Admin                                                  ║");

        Console.Write("    ║  ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("0.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Salir                                                  ║");

        Console.WriteLine("    ╚═══════════════════════════════════════════════════════════════╝");

        // Añade una pequeña animación de corazón parpadeante
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(24, 28);
            Console.Write("♥ ♥ ♥");
            Thread.Sleep(300);
            Console.SetCursorPosition(24, 28);
            Console.Write("      ");
            Thread.Sleep(300);
        }
        Console.SetCursorPosition(24, 28);
        Console.Write("♥ ♥ ♥");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, 30);
        Console.Write("\n    Selecciona una opción: ");
        Console.ForegroundColor = ConsoleColor.White;
    }
    ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (keyPressed.KeyChar)
            {
                case '1':
                    UiLogin.MenuLogin();
                    break;
                case '2':
                    UiRegistro.MenuRegistro();
                    break;
                case '3':
                    UiAdminMenu.MenuAdmin();
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
