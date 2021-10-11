using Encuesta.Data;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IUsuariosRepository
    {
        Task InsertarUsuarioRepository(TblUsuarios usuario);
    }
}
