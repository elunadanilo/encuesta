using Encuesta.Data;
using Encuesta.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IRespuestasRepository
    {
        //Task<ListadoRespuestasEncuesta> ObtenerListadoRespuestasRepository(Guid encuesta);
        Task<List<ListadoRespuestasEncuesta>> ObtenerListadoRespuestasRepository(Guid encuesta);
        Task InsertarRespuestaRepository(TblRespuestas respuesta);
    }
}
