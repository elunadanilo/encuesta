using Encuesta.Data;
using Encuesta.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encuesta.Repositories
{
    public class ListadoCamposRepository : IListadoCamposRepository
    {
        private readonly DbEncuestaContext _context;
        public ListadoCamposRepository(DbEncuestaContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarListadoCampoRepository(TblListadoCampos listado)
        {
            var currentListado = await ObtenerListadoCampoRepository(listado.IdListadoCampoEncuesta, new Guid(listado.Encuesta));
            currentListado.Nombre = listado.Nombre;
            currentListado.Titulo = listado.Titulo;
            currentListado.Requerido = listado.Requerido;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> EliminarListadoCampoRepository(int id, Guid listado)
        {
            var currentListado = await ObtenerListadoCampoRepository(id, listado);
            _context.TblListadoCampos.Remove(currentListado);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task InsertarListadoCampoRepository(TblListadoCampos listado)
        {
            _context.TblListadoCampos.Add(listado);
            await _context.SaveChangesAsync();
        }

        public async Task<TblListadoCampos> ObtenerListadoCampoRepository(int id, Guid listado)
        {
            var client = await _context.TblListadoCampos.FirstOrDefaultAsync(x => x.IdListadoCampoEncuesta == id && x.Encuesta == listado.ToString());
            return client;
        }

        public async Task<TblListadoCampos> ObtenerListadoCampoEncuestaRepository(Guid listado)
        {
            var client = await _context.TblListadoCampos.FirstOrDefaultAsync(x => x.Encuesta == listado.ToString());
            return client;
        }

        public async Task<IEnumerable<TblListadoCampos>> ObtenerListadoCamposRepository()
        {
            var listado = await _context.TblListadoCampos.ToListAsync();
            return listado;
        }
    }
}
