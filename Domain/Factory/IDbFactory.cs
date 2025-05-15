using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;

namespace CampusLove.Domain.Factory;

public interface IDbFactory
{
    IUserRepository CreateUserRepository();
    IEstadisticasRepository CreateEstadisticasRepository();
    ISesionRepository CreateSesionRepository();
    ICarreraRepository CreateCarreraRepository();
    IInteresesRepository CreateInteresRepository();
}
