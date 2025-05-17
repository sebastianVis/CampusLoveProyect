using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Domain.Ports
{
    public interface ICarreraRepository : IGenericRepository<Carrera>
    {
        void AgregarCarrera(Usuario usuario, int idCarrera);
    }
}