using Encuesta.Data;
using Encuesta.Data.Models;
using Encuesta.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface ILoginRepository
    {
        Task<TblUsuarios> ValidarCredencialesRepository(UserLogin usuario);
    }
}
