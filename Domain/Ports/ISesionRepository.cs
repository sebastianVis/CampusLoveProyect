using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Domain.Ports;

public interface ISesionRepository
{
    void AbrirSesion(int id);
    void CerrarSesion(int id);
}
