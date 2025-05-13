using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Domain.Entities;
public class Estadisticas
{
    public int IdEstadistica { get; set; }
    public int IdUsuario { get; set; }
    public int LikesRecibidos { get; set; }
    public int DislikesRecibidos { get; set; }
    public int TotalMatches { get; set; }
    public DateTime UtimaActualizacion { get; set; }
}
