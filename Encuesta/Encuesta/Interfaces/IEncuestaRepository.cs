using Encuesta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IEncuestaRepository
    {
        Task<IEnumerable<TblEncuesta>> ObtenerEncuestasRepository();
        Task<TblEncuesta> ObtenerEncuestaRepository(Guid id);
        Task InsertarEncuestaRepository(TblEncuesta encuesta);
        Task<bool> ActualizarEncuestaRepository(TblEncuesta encuesta);
        Task<bool> EliminarEncuestaRepository(Guid id);
    }
}
