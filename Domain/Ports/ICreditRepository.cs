using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Domain.Ports;

public interface ICreditRepository
{
    void AddCredit(Usuario usuario);
    void CreateCreditUser(Usuario usuario);
    int ObtenerCreditos(Usuario usuario);
    void removeCredit(Usuario usuario);
}
