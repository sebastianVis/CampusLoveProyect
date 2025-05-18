using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Domain.Ports
{
    public interface IInteresesRepository : IGenericRepository<Intereses>
    {
        string NombreInteres(Usuario entity);
    }
}