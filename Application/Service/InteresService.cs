using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;

namespace CampusLove.Application.Service
{
    public class InteresService
    {
        private readonly IInteresesRepository _repo;
    public InteresService(IInteresesRepository repo)
    {
        _repo = repo;
    }

    public void CrearIntereses(Intereses Intereses)
    {
        _repo.Crear(Intereses);
    }

    public void ObtenerInteresess()
    {
        var lista = _repo.Obtener();
        foreach (var a in lista)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nID: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(a.IdInteres.ToString().PadRight(4));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nombre: ");
            Console.ForegroundColor = ConsoleColor.White;

            string nombreMostrado = a.Nombre?.PadRight(15) ?? "".PadRight(15);
            Console.Write(nombreMostrado);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void EliminarIntereses(int id)
    {
        _repo.Eliminar(id);
    }

    public void EditarIntereses(Intereses Intereses)
    {
        _repo.Actualizar(Intereses);
    }
        
    }
}