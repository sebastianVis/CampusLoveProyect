using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Domain.Entities;
    public class Matches
    {
        public int IdMatch { get; set; }
        public int IdUsuarioUno { get; set; }
        public int IdUsuarioDos { get; set; }
        public DateTime FechaMatch { get; set; }
        
    }
