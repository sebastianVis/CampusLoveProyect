using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;

namespace CampusLove.Application.Service;

public class EstadisticasService
{
    private readonly IEstadisticasRepository _repo;

    public EstadisticasService(IEstadisticasRepository repo)
    {
        _repo = repo;
    }

    public void VerEstadisticas(Usuario entity)
    {
        _repo.VerEstadisticas(entity);
    }

    public void CrearEntidad(Usuario entity)
    {
        _repo.Crear(entity);
    }

    public void ActualizarLikes(Usuario entity, int likes)
    {
        _repo.ActualizarLikes(entity, likes);
    }

    public void ActualizarDislikes(Usuario entity, int dislikes)
    {
        _repo.ActualizarDislikes(entity, dislikes);
    }

    public void Eliminar(int id)
    {
        _repo.Eliminar(id);
    }

    public bool VerificarLike(int idUsuarioActual, int idUsuarioDestino)
    {
        return _repo.VerificarLike(idUsuarioActual, idUsuarioDestino);
    }
}
