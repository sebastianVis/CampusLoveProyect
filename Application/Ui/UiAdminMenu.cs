using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Application.Ui
{
    public class UiAdminMenu
    {
        public static void MenuAdmin()
        {
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;

                // Cabecera
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

                string titulo = "PANEL DE ADMINISTRACIÓN";
                int espaciosTitulo = (49 - titulo.Length) / 2;
                Console.Write($"    ║{new string(' ', espaciosTitulo)}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(titulo);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{new string(' ', 49 - titulo.Length - espaciosTitulo)}║");

                Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

                // Logo compacto
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("    ║               CAMPUS LOVE - ADMINISTRADOR             ║");
                Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

                // Menú principal
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("    ╔═══════════════════════════════════════════════════════╗");

                // Opciones con íconos
                Console.Write("    ║  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" 🎓 Gestión de Carreras                           ║");

                Console.WriteLine("    ║                                                       ║");

                Console.Write("    ║  ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("2.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" 👤 Gestión de Usuarios                           ║");

                Console.WriteLine("    ║                                                       ║");

                Console.Write("    ║  ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" 🔍 Gestión de Intereses                          ║");

                Console.WriteLine("    ║                                                       ║");

                Console.Write("    ║  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("0.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" 🔙 Volver al Menú Principal                      ║");

                Console.WriteLine("    ╚═══════════════════════════════════════════════════════╝");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n    Selecciona una opción: ");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                switch (keyPressed.KeyChar)
                {
                    case '1':
                        UiCarrera.MenuCarrera();
                        break;
                    case '2':
                        UiCarrera.MenuCarrera();
                        break;
                    case '3':
                        UiInteres.MenuInteres();
                        break;
                    case '0':
                        UiMainMenu.MainMenu();
                        break;
                }
            }
        }
    }
}