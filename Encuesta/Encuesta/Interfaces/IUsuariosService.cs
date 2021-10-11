using Encuesta.Data;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IUsuariosService
    {
        Task InsertarUsuarioService(TblUsuarios usuario);
    }
}
