using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Controllers.CompletarEncuesta.DTO
{
    public class RespuestasEncuestaDTO
    {
        public int IdListadoCampoEncuesta { get; set; }
        public string Respuesta { get; set; }
        public string TipoDeCampo { get; set; }
        public bool Requerido { get; set; }
    }
}
