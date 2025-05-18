using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;

namespace CampusLove.Application.Service;

public class CarreraService
{
    private readonly ICarreraRepository _repo;
    public CarreraService(ICarreraRepository repo)
    {
        _repo = repo;
    }

    public void CrearCarrera(Carrera carrera)
    {
        _repo.Crear(carrera);
    }

    public void ObtenerCarreras()
    {
        var lista = _repo.Obtener();
        foreach (var a in lista)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nID: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(a.IdCarrera.ToString().PadRight(4));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nombre: ");
            Console.ForegroundColor = ConsoleColor.White;

            string nombreMostrado = a.Nombre?.PadRight(15) ?? "".PadRight(15);
            Console.Write(nombreMostrado);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void EliminarCarrera(int id)
    {
        _repo.Eliminar(id);
    }

    public void EditarCarrera(Carrera carrera)
    {
        _repo.Actualizar(carrera);
    }
    public string NombreCarrera(Usuario usuario)
        {
            return _repo.NombreCarrera(usuario);
        }
}
