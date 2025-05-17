using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;

namespace CampusLove.Domain.Ports;

public interface IEstadisticasRepository : IGenericRepository<Usuario>
{
    void VerEstadisticas(Usuario usuario);
    void ActualizarLikes(Usuario usuario, int likes);
    void ActualizarDislikes(Usuario usuario, int likes);
    bool VerificarLike(int idUsuarioEmisor, int idUsuarioReceptor);
}
