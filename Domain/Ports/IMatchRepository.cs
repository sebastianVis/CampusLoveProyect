using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Domain.Ports
{
    public interface IMatchRepository
    {
        void CreateMatch(Usuario usuarioUno, Usuario usuarioDos);
    }
}