using Encuesta.Data;
using Encuesta.Data.Models;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DbEncuestaContext _context;

        public LoginRepository(DbEncuestaContext context)
        {
            _context = context;
        }
        public async Task<TblUsuario> ValidarCredencialesRepository(UserLogin usuario)
        {
            return await _context.TblUsuarios.FirstOrDefaultAsync(x => x.Usuario == usuario.User && x.Password == usuario.Password);
        }
    }
}
