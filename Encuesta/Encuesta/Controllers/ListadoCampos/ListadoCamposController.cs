using AutoMapper;
using Encuesta.Controllers.ListadoCampos.DTO;
using Encuesta.Data;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Encuesta.Controllers.ListadoCampos
{

    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ListadoCamposController : ControllerBase
    {
        private readonly IListadoCamposService _listadoCamposService;

        private readonly IMapper _mapper;

        public ListadoCamposController(IListadoCamposService listadoCamposService, IMapper mapper)
        {
            _listadoCamposService = listadoCamposService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene el listado de todos los campos o preguntas asignadas a una encuesta
        /// </summary>
        [HttpGet(Name = nameof(ObtenerListadoCampos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ListadoCamposDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ObtenerListadoCampos()
        {
            var listado = await _listadoCamposService.ObtenerListadoCamposService();

            var listadoDto = _mapper.Map<IEnumerable<ListadoCamposDTO>>(listado);

            var response = new ApiResponse<IEnumerable<ListadoCamposDTO>>(listadoDto);


            return Ok(response);
        }

        /// <summary>
        /// Obtiene el campo o pregunta asignada a una encuesta por id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerListadoCampo(int idlistado, Guid id)
        {
            var listado = await _listadoCamposService.ObtenerListadoCampoService(idlistado, id);

            var listadoDto = _mapper.Map<ListadoCamposDTO>(listado);

            var response = new ApiResponse<ListadoCamposDTO>(listadoDto);

            return Ok(response);
        }

        /// <summary>
        /// Obtiene el campo o pregunta a una encuesta
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertarListadoCampos(ListadoCamposDTO listadoDto)
        {
            var listado = _mapper.Map<TblListadoCampos>(listadoDto);

            await _listadoCamposService.InsertarListadoCampoService(listado);

            listadoDto = _mapper.Map<ListadoCamposDTO>(listado);

            var response = new ApiResponse<ListadoCamposDTO>(listadoDto);

            return Ok(response);
        }

        /// <summary>
        /// Actualiza el campo o pregunta asignada a una encuesta
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ActualizarListadoCampos(ListadoCamposDTO listadoDto)
        {
            var listado = _mapper.Map<TblListadoCampos>(listadoDto);
            listado.Encuesta = listadoDto.Encuesta;
            listado.IdListadoCampoEncuesta = listado.IdListadoCampoEncuesta;

            var result = await _listadoCamposService.ActualizarListadoCampoService(listado);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        /// <summary>
        /// Elimina el campo o pregunta asignada a una encuesta
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarListadoCampos(int idlistado, Guid encuesta)
        {
            var result = await _listadoCamposService.EliminarListadoCampoService(idlistado, encuesta);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
