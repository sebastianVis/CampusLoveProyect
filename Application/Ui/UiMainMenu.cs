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
            Console.Clear();
            Console.WriteLine("\n\t\t--CAMPUS LOVE --\n\n");
            Console.WriteLine("\t1. Iniciar sesión\n\t2. Registrar usuario\n\t0. Salir");
            Console.Write("\nOpción: ");
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            switch (keyPressed.KeyChar)
            {
                case '1':
                    UiLogin.MenuLogin();
                    break;
                case '2':
                    UiRegistro.MenuRegistro();
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
