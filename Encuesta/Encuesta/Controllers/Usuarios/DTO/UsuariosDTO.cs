using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Controllers.Usuarios.DTO
{
    public class UsuariosDTO
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Administrador { get; set; }
        public bool Activo { get; set; }
    }
}
