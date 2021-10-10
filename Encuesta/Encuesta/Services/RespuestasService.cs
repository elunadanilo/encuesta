using Encuesta.Data;
using Encuesta.Data.Models;
using Encuesta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Services
{
    public class RespuestasService : IRespuestasService
    {
        private readonly IRespuestasRepository _respuestasRepository;
        private readonly IEncuestaService _encuestaService;
        private readonly IListadoCamposService _listadoCamposService;
        public RespuestasService(
            IRespuestasRepository respuestasRepository,
            IEncuestaService encuestaService,
            IListadoCamposService listadoCamposService
            )
        {
            _respuestasRepository = respuestasRepository;
            _encuestaService = encuestaService;
            _listadoCamposService = listadoCamposService;
        }
        public async Task InsertarRespuestaService(TblRespuestas respuesta)
        {
            await _respuestasRepository.InsertarRespuestaRepository(respuesta);
        }

        public async Task<List<ListadoRespuestasEncuesta>> ObtenerListadoRespuestasService(Guid encuesta)
        {
            return await _respuestasRepository.ObtenerListadoRespuestasRepository(encuesta);
        }
    }
}
