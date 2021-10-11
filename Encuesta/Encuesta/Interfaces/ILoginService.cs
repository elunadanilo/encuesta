using Encuesta.Data;
using Encuesta.Data.Models;
using System;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface ILoginService
    {
        Task<String> GenerarTokenService(TblUsuarios usuario = null, string oldtoken = null);
        Task<TblUsuarios> ValidarCredencialesService(UserLogin usuario);
    }
}
