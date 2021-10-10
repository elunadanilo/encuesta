using Encuesta.Data;
using Encuesta.Data.Models;
using System;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface ILoginService
    {
        Task<String> GenerarTokenService(TblUsuario usuario = null, string oldtoken = null);
        Task<TblUsuario> ValidarCredencialesService(UserLogin usuario);
    }
}
