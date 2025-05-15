using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CampusLove.Application.Ui;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;

namespace CampusLove.Application.Service;

public class UsuarioService
{
    private readonly IUserRepository _repo;
    public UsuarioService(IUserRepository repo)
    {
        _repo = repo;
    }
    public void CrearUsuario(Usuario entity)
    {
        _repo.Crear(entity);
    }
    public void ObtenerUsuarios()
    {
        var lista = _repo.Obtener();
        foreach (var a in lista)
        {
            string genero = "";
            switch (a.IdGenero)
            {
                case 1:
                    genero = "Masculino";
                    return;
                case 2:
                    genero = "Femenino";
                    return;
            }
            Console.WriteLine($"Id: {a.IdUsuario}, Nombre: {a.Nombre}, Edad: {a.Edad}, \nGenero: {genero}");
        }
    }
    public void EliminarUsuario(int idUser)
    {
        _repo.Eliminar(idUser);
    }
    public void EditarUsuario(Usuario usuario)
    {
        _repo.Actualizar(usuario);
    }

    public void EditarLogin(Usuario usuario)
    {
        _repo.ActualizarLogin(usuario);
    }

    public bool ObtenerLogin(Usuario usuario)
    {
        return _repo.ObtenerLogin(usuario);
    }

    public Usuario ObtenerUsuario(Usuario usuario)
    {
        return _repo.ObtenerId(usuario);
    }
}
