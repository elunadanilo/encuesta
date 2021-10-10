using AutoMapper;
using Encuesta.Controllers.CompletarEncuesta.DTO;
using Encuesta.Data;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Encuesta.Controllers.CompletarEncuesta
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompletarEncuestaController : ControllerBase
    {
        private readonly IEncuestaService _encuestaService;
        private readonly IRespuestasService _respuestasService;
        private readonly IListadoCamposService _listadoCampoService;
        private readonly IMapper _mapper;

        public CompletarEncuestaController(IEncuestaService encuestaService, IRespuestasService respuestasService, IListadoCamposService listadoCampoService, IMapper mapper)
        {
            _encuestaService = encuestaService;
            _respuestasService = respuestasService;
            _listadoCampoService = listadoCampoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene los campos o preguntas asignada a una encuesta para ser contestadas
        /// </summary>

        [HttpGet("{encuesta}")]
        public async Task<IActionResult> ObtenerListadoRespuestasEncuesta(Guid encuesta)
        {
            var encuestaListado = await _listadoCampoService.ObtenerListadoCampoEncuestaService(encuesta);

            var encuestaDto = _mapper.Map<PreguntasEncuestaDTO>(encuestaListado);

            var response = new ApiResponse<PreguntasEncuestaDTO>(encuestaDto);

            return Ok(response);
        }

        /// <summary>
        /// Graba las respuestas del usuario en una encuesta
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertarRespuestasEncuesta(RespuestasEncuestaDTO respuestasDto)
        {
            var respuestas = _mapper.Map<TblRespuestas>(respuestasDto);

            await _respuestasService.InsertarRespuestaService(respuestas);

            respuestasDto = _mapper.Map<RespuestasEncuestaDTO>(respuestas);

            var response = new ApiResponse<RespuestasEncuestaDTO>(respuestasDto);

            return Ok(response);
        }
    }
}
