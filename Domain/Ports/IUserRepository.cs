using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Domain.Ports;

public interface IUserRepository : IGenericRepository<Usuario>
{
    void ActualizarLogin(Usuario entity);
    bool ObtenerLogin(Usuario entity);
    Usuario ObtenerId(Usuario entity);

    void TinderIniciar(int id);
    }
