using Encuesta.Data;
using Encuesta.Exceptions;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using System.Threading.Tasks;

namespace Encuesta.Repositories
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }
        public async Task InsertarUsuarioService(TblUsuarios usuario)
        {
            try
            {
                await _usuariosRepository.InsertarUsuarioRepository(usuario);
            }
            catch (System.Exception exc)
            {
                Log.doLog($"{exc}");
                throw new BusinessException("Error al grabar usuario");
            }

        }
    }
}
