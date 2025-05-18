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
            string genero = "nadota";
            switch (a.IdGenero)
            {
                case 1:
                    genero = "Masculino";
                    break;
                case 2:
                    genero = "Femenino";
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ID: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(a.IdUsuario.ToString().PadRight(4));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nombre: ");
            Console.ForegroundColor = ConsoleColor.White;

            string nombreMostrado = a.Nombre?.PadRight(15) ?? "".PadRight(15);
            Console.Write(nombreMostrado);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Edad: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(a.Edad.ToString()!.PadRight(3));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Género: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(genero);

            Console.ForegroundColor = ConsoleColor.White;
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

    public Usuario ObtenerId(Usuario entity)
    {
        return _repo.ObtenerId(entity);
    }

    public List<Usuario> ObtenerUsuariosTinder()
    {
        var lista = _repo.Obtener();
        foreach (var a in lista)
        {
            string genero = "";
            switch (a.IdGenero)
            {
                case 1:
                    genero = "Masculino";
                    break;
                case 2:
                    genero = "Femenino";
                    break;
            }
            Console.WriteLine($"Id: {a.IdUsuario}, Nombre: {a.Nombre}, Edad: {a.Edad}, Genero: {genero}");
        }
        return lista;
    }

    public void AddUsuarioCarrera(Usuario entity, int idCarrera)
    {
        _repo.AddUsuarioCarrera(entity, idCarrera);
    }

    public void AddUsuarioInteres(Usuario entity, int idInteres)
    {
        _repo.AddUsuarioInteres(entity, idInteres);
    }
}
