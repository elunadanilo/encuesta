using AutoMapper;
using Encuesta.Controllers.Encuesta.DTO;
using Encuesta.Data;
using Encuesta.Data.Models;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Encuesta.Controllers.Encuesta
{
   // [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaService _encuestaService;
        private readonly IRespuestasService _respuestasService;
        private readonly IMapper _mapper;

        public EncuestaController(IEncuestaService encuestaService, IRespuestasService respuestasService, IMapper mapper)
        {
            _encuestaService = encuestaService;
            _respuestasService = respuestasService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene el listado de encabezados de las encuestas existentes
        /// </summary>
        [HttpGet(Name = nameof(ObtenerEncuestas))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<EncuestaDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ObtenerEncuestas()
        {
            var encuesta = await _encuestaService.ObtenerEncuestasServicey();

            var encuestaDto = _mapper.Map<IEnumerable<EncuestaDTO>>(encuesta);

            var response = new ApiResponse<IEnumerable<EncuestaDTO>>(encuestaDto);


            return Ok(response);
        }

        /// <summary>
        /// Obtiene una encabezado de encuesta por id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerEncuesta(Guid id)
        {
            var encuesta = await _encuestaService.ObtenerEncuestaService(id);

            var encuestaDto = _mapper.Map<EncuestaDTO>(encuesta);

            var response = new ApiResponse<EncuestaDTO>(encuestaDto);

            return Ok(response);
        }

        /// <summary>
        /// Graba un nuevo encabezado de una encuesta
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertarEncuesta(EncuestaDTO encuestaDto)
        {
            var encuesta = _mapper.Map<TblEncuesta>(encuestaDto);

            await _encuestaService.InsertarEncuestaService(encuesta);

            encuestaDto = _mapper.Map<EncuestaDTO>(encuesta);

            var response = new ApiResponse<EncuestaDTO>(encuestaDto);

            return Ok(response);
        }


        /// <summary>
        /// Actualiza un nuevo encabezado de encuesta
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ActualizarEncuesta(Guid id, EncuestaDTO encuestaDto)
        {
            var encuesta = _mapper.Map<TblEncuesta>(encuestaDto);
            encuesta.IdEncuesta =id;

            var result = await _encuestaService.ActualizarEncuestaService(encuesta);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        /// <summary>
        /// Elimina un encabezado de encuesta por id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEncuesta(Guid id)
        {
            var result = await _encuestaService.EliminarEncuestaService(id);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        /// <summary>
        /// Obtiene el resultado de las encuestas contestadas
        /// </summary>
        [HttpGet("respuestas/{id}")]
        public async Task<IActionResult> ObtenerResultadosEncuesta(Guid id)
        {
            var encuesta = await _respuestasService.ObtenerListadoRespuestasService(id);

            //var encuestaDto = _mapper.Map<ListadoRespuestasEncuesta>(encuesta);

           // var response = new ApiResponse<ListadoRespuestasEncuesta>(encuestaDto);

            return Ok(encuesta);
        }
    }
}
