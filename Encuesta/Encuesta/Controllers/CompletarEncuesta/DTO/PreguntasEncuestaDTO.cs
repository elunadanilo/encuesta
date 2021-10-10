using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Controllers.CompletarEncuesta.DTO
{
    public class PreguntasEncuestaDTO
    {
        public int IdListadoCampoEncuesta { get; set; }
        public string Encuesta { get; set; }
        public string Titulo { get; set; }
        public bool Requerido { get; set; }
        public string TipoDeCampo { get; set; }
    }
}
