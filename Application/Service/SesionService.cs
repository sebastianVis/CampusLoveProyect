using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Ports;

namespace CampusLove.Application.Service;

public class SesionService
{
    private readonly ISesionRepository _repo;

    public SesionService(ISesionRepository repo)
    {
        _repo = repo;
    }

    public void AbrirSesion(int id)
    {
        _repo.AbrirSesion(id);
    }

    public void CerrarSesion(int id)
    {
        _repo.CerrarSesion(id);
    }
}