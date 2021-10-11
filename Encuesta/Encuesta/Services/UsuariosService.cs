using Encuesta.Data;
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
            await _usuariosRepository.InsertarUsuarioRepository(usuario);
        }
    }
}
