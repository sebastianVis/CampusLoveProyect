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
        foreach (var c in lista)
        {
            Console.WriteLine($"Id: {c.IdCarrera}, Nombre Carrera: {c.Nombre}");
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
}
