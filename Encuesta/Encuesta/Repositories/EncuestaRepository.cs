using Encuesta.Data;
using Encuesta.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Repositories
{
    public class EncuestaRepository : IEncuestaRepository
    {
        private readonly DbEncuestaContext _context;
        public EncuestaRepository(DbEncuestaContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarEncuestaRepository(TblEncuesta encuesta)
        {
            var currentEncuesta = await ObtenerEncuestaRepository(encuesta.IdEncuesta);
            currentEncuesta.NombreEncuesta = encuesta.NombreEncuesta;
            currentEncuesta.Descripcion = encuesta.Descripcion;
            currentEncuesta.FechaCreacion = encuesta.FechaCreacion;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> EliminarEncuestaRepository(Guid id)
        {
            var currentEncuesta = await ObtenerEncuestaRepository(id);
            _context.TblEncuesta.Remove(currentEncuesta);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task InsertarEncuestaRepository(TblEncuesta encuesta)
        {
            _context.TblEncuesta.Add(encuesta);
            await _context.SaveChangesAsync();
        }

        public async Task<TblEncuesta> ObtenerEncuestaRepository(Guid id)
        {
            var client = await _context.TblEncuesta.FirstOrDefaultAsync(x => x.IdEncuesta ==id);
            return client;
        }

        public async Task<IEnumerable<TblEncuesta>> ObtenerEncuestasRepository()
        {
            var encuestas = await _context.TblEncuesta.ToListAsync();
            return encuestas;
        }
    }
}
