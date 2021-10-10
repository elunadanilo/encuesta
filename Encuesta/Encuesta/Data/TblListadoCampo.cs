using System;
using System.Collections.Generic;

#nullable disable

namespace Encuesta.Data
{
    public partial class TblListadoCampos
    {
        public int IdListadoCampoEncuesta { get; set; }
        public string Encuesta { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public bool Requerido { get; set; }
        public string TipoDeCampo { get; set; }
    }
}
