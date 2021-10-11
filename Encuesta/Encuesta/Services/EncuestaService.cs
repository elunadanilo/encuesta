using Encuesta.Data;
using Encuesta.Exceptions;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Services
{
    public class EncuestaService : IEncuestaService
    {
        private readonly IEncuestaRepository _encuestaRepository;

        public EncuestaService(IEncuestaRepository encuestaRepository)
        {
            _encuestaRepository = encuestaRepository;
        }

        public async Task<bool> ActualizarEncuestaService(TblEncuesta encuesta)
        {
            try
            {
                return await _encuestaRepository.ActualizarEncuestaRepository(encuesta);
            }
            catch (Exception exc)
            {
                Log.doLog($"{exc}");
                throw new BusinessException("Error al actualizar encabezado de encuesta");
            }
        }

        public async Task<bool> EliminarEncuestaService(Guid id)
        {
            try
            {
                return await _encuestaRepository.EliminarEncuestaRepository(id);
            }
            catch (Exception exc)
            {
                Log.doLog($"{exc}");
                throw new BusinessException("Error al eliminar encabezado de encuesta");
            }
        }

        public async Task InsertarEncuestaService(TblEncuesta encuesta)
        {
            try
            {
                await _encuestaRepository.InsertarEncuestaRepository(encuesta);
            }
            catch (Exception exc)
            {
                Log.doLog($"{exc}");
                throw new BusinessException("Error al grabar encabezado de encuesta");
            }
        }

        public async Task<TblEncuesta> ObtenerEncuestaService(Guid id)
        {
            return await _encuestaRepository.ObtenerEncuestaRepository(id);
        }

        public async Task<IEnumerable<TblEncuesta>> ObtenerEncuestasServicey()
        {
            var encuestas = await _encuestaRepository.ObtenerEncuestasRepository();

            return encuestas;
        }
    }
}
