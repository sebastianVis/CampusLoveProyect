using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;

namespace CampusLove.Application.Service;

public class CreditosService
{
    private readonly ICreditRepository _repo;
    public CreditosService(ICreditRepository repo)
    {
        _repo = repo;
    }

    public void CrearCreditosUsuario(Usuario usuario)
    {
        _repo.CreateCreditUser(usuario);
    }

    public void AgregarCreditos(Usuario usuario)
    {
        _repo.AddCredit(usuario);
    }

    public int ObtenerCreditos(Usuario usuario)
    {
        return _repo.ObtenerCreditos(usuario);
    }

    public void QuitarCreditos(Usuario usuario)
    {
        _repo.removeCredit(usuario);
    }

}
