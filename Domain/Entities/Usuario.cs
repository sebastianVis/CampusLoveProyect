using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public int? Edad { get; set; }
        public string? FrasePerfil {get; set; }
        public int IdGenero {get ; set;}
    }
}