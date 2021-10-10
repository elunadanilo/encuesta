using Encuesta.Data;
using Encuesta.Data.Models;
using Encuesta.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Repositories
{
    public class RespuestasRepository : IRespuestasRepository
    {
        private readonly DbEncuestaContext _context;
        public RespuestasRepository(DbEncuestaContext context)
        {
            _context = context;
        }
        public async Task InsertarRespuestaRepository(TblRespuestas respuesta)
        {
            _context.TblRespuestas.Add(respuesta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ListadoRespuestasEncuesta>> ObtenerListadoRespuestasRepository(Guid encuesta)
        {
            try
            {
                List<ListadoRespuestasEncuesta> listaRespuestas = null;

                using (_context)
                {
                    listaRespuestas = await (from preguntas in _context.TblEncuesta
                                             join listados in _context.TblListadoCampos on preguntas.IdEncuesta.ToString() equals listados.Encuesta
                                             join respuesta in _context.TblRespuestas on listados.IdListadoCampoEncuesta equals respuesta.IdListadoCampoEncuesta
                                             where preguntas.IdEncuesta == encuesta
                                             select new ListadoRespuestasEncuesta
                                             {
                                                 NombreEncuesta = preguntas.NombreEncuesta,
                                                 Descripcion = preguntas.Descripcion,
                                                 Pregunta = listados.Titulo,
                                                 Respuesta = respuesta.Respuesta
                                             }).ToListAsync();
                }
                return listaRespuestas;
            }
            catch (Exception ex)
            {

                throw ex;
            }         
        }
    }
}
