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
        foreach (var c in lista)
        {
            Console.WriteLine($"Id: {c.IdInteres}, Nombre Intereses: {c.Nombre}");
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