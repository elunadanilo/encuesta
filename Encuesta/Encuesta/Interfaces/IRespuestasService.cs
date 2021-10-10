using Encuesta.Data;
using Encuesta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IRespuestasService
    {
        //Task<ListadoRespuestasEncuesta> ObtenerListadoRespuestasService(Guid encuesta);
        Task<List<ListadoRespuestasEncuesta>> ObtenerListadoRespuestasService(Guid encuesta);
        Task InsertarRespuestaService(TblRespuestas respuesta);
    }
}
