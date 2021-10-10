using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Data.Models
{
    public class ListadoRespuestasEncuesta
    {
        public string NombreEncuesta { get; set; }
        public string Descripcion { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }

    }
}
