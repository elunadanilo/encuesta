using System;
using System.Collections.Generic;

#nullable disable

namespace Encuesta.Data
{
    public partial class TblUsuario
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Administrador { get; set; }
        public bool Activo { get; set; }
    }
}
