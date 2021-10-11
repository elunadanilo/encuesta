using AutoMapper;
using Encuesta.Controllers.Usuarios.DTO;
using Encuesta.Data;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Encuesta.Controllers.Usuarios
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IMapper _mapper;
        public UsuariosController(IUsuariosService usuariosService, IMapper mapper)
        {
            _usuariosService = usuariosService;
            _mapper = mapper;
        }

        /// <summary>
        /// Graba un nuevo usuario
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertarUsuario(UsuariosDTO usuarioDto)
        {
            var usuario = _mapper.Map <TblUsuarios>(usuarioDto);

            await _usuariosService.InsertarUsuarioService(usuario);

            usuarioDto = _mapper.Map<UsuariosDTO>(usuario);

            var response = new ApiResponse<UsuariosDTO>(usuarioDto);

            return Ok(response);
        }
    }
}
