using System;
using System.Collections.Generic;

#nullable disable

namespace Encuesta.Data
{
    public partial class TblRespuestas
    {
        public int IdRespuesta { get; set; }
        public int IdListadoCampoEncuesta { get; set; }
        public string Respuesta { get; set; }
    }
}
