using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Application.Ui;

public class UiMenu
{
    public static void MenuStart(Usuario usuario)
    {
        Console.Clear();
        Console.WriteLine($"\t\t-- BIENVENIDO {usuario.Nombre} --");
        Console.WriteLine("\n\t1. Interactuar\t\t2. Ver estadisticas\n\t3. Editar informacion\t4. Cambiar usuario/contraseña\n\t0. Cerrar sesión");
        Console.ReadLine();
    }
}
