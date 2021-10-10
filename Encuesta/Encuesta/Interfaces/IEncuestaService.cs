using Encuesta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IEncuestaService
    {
        Task<IEnumerable<TblEncuesta>> ObtenerEncuestasServicey();
        Task<TblEncuesta> ObtenerEncuestaService(Guid id);
        Task InsertarEncuestaService(TblEncuesta encuesta);
        Task<bool> ActualizarEncuestaService(TblEncuesta encuesta);
        Task<bool> EliminarEncuestaService(Guid id);
    }
}
