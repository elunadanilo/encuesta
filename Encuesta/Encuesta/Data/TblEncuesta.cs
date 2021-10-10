using System;
using System.Collections.Generic;

#nullable disable

namespace Encuesta.Data
{
    public partial class TblEncuesta
    {
        public Guid IdEncuesta { get; set; }
        public string NombreEncuesta { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
