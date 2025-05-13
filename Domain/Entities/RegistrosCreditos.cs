using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Domain.Entities
{
    public class RegistrosCreditos
    {
        public int IdRegistro { get; set; }
        public int IdUsuario { get; set; }
        public int CreditosAnteriores { get; set; }
        public int CreditosNuevos { get; set; }
        public string? Motivo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}