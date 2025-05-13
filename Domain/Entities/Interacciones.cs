using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Domain.Entities;
public class Interacciones
{
    public int IdInteraccion { get; set; }
    public int IdUsuarioEmisor { get; set; }
    public int IdUsuarioReceptor { get; set; }
    public int IdTipoInteraccion { get; set; }
    public DateTime FechaInteraccion { get; set; }
}
