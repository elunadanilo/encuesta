using Encuesta.Data;
using Encuesta.Interfaces;
using System.Threading.Tasks;

namespace Encuesta.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly DbEncuestaContext _context;
        public UsuariosRepository(DbEncuestaContext context)
        {
            _context = context;
        }
        public async Task InsertarUsuarioRepository(TblUsuarios usuario)
        {
            _context.TblUsuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
