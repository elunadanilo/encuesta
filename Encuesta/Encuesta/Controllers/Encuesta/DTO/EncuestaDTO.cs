using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Controllers.Encuesta.DTO
{
    public class EncuestaDTO
    {
        public Guid IdEncuesta { get; set; }
        public string NombreEncuesta { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
