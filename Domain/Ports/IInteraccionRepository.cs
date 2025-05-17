using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Domain.Ports;

public interface IInteraccionRepository
{
    void CrearInteraccion(Usuario usuarioUno, Usuario usuarioDos, int idInteraccion);
    void EliminarInteraccion(Usuario usuarioUno);
}