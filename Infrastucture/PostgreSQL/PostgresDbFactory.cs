using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Factory;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.Repositories;

namespace CampusLove.Infrastucture.PostgreSQL;

public class PostgresDbFactory : IDbFactory
{
    private readonly string _connectionString;

    public PostgresDbFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    public IUserRepository CreateUserRepository()
    {
        return new ImpUserRepository(_connectionString);
    }

    public IEstadisticasRepository CreateEstadisticasRepository()
    {
        return new ImpEstadisticasRepository(_connectionString);
    }

    public ISesionRepository CreateSesionRepository()
    {
        return new ImpSesionRepository(_connectionString);
    }

    public ICarreraRepository CreateCarreraRepository()
    {
        return new ImpCarreraRepository(_connectionString);
    }
    public IInteresesRepository CreateInteresRepository()
    {
        return new ImpInteresesRepository(_connectionString);
    }
    public IMatchRepository CreateMatchRepository()
    {
        return new ImpMatchRepository(_connectionString);
    }
    public IInteraccionRepository CreateInteraccionRepository()
    {
        return new ImpInteraccionRepository(_connectionString);
    }
}
