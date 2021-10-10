using Encuesta.Data;
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
            return await _encuestaRepository.ActualizarEncuestaRepository(encuesta);
        }

        public async Task<bool> EliminarEncuestaService(Guid id)
        {
            return await _encuestaRepository.EliminarEncuestaRepository(id);
        }

        public async Task InsertarEncuestaService(TblEncuesta encuesta)
        {
            await _encuestaRepository.InsertarEncuestaRepository(encuesta);
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
