using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Ports;
using CampusLove.Domain.Entities;

namespace CampusLove.Application.Service;

public class InteraccionService
{
    private readonly IInteraccionRepository _repo;
    public InteraccionService(IInteraccionRepository repo)
    {
        _repo = repo;
    }

    public void CrearInteraccion(Usuario usuarioUno, Usuario usuarioDos, int idInteraccion)
    {
        _repo.CrearInteraccion(usuarioUno, usuarioDos, idInteraccion);
    }

    public void BorrarInteraccion(Usuario usuario)
    {
        _repo.EliminarInteraccion(usuario);
    }
}
