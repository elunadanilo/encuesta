using Encuesta.Data;
using Encuesta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuesta.Repositories
{
    public class ListadoCamposService : IListadoCamposService
    {
        private readonly IListadoCamposRepository _listadoCamposRepository;

        public ListadoCamposService(IListadoCamposRepository listadoCamposRepository)
        {
            _listadoCamposRepository = listadoCamposRepository;
        }
        public async Task<bool> ActualizarListadoCampoService(TblListadoCampos listado)
        {
            return await _listadoCamposRepository.ActualizarListadoCampoRepository(listado);
        }

        public async Task<bool> EliminarListadoCampoService(int id, Guid listado)
        {
            return await _listadoCamposRepository.EliminarListadoCampoRepository(id,listado);
        }

        public async Task InsertarListadoCampoService(TblListadoCampos listado)
        {
            await _listadoCamposRepository.InsertarListadoCampoRepository(listado);
        }

        public async Task<TblListadoCampos> ObtenerListadoCampoEncuestaService(Guid listado)
        {
            return await _listadoCamposRepository.ObtenerListadoCampoEncuestaRepository(listado);
        }

        public async Task<TblListadoCampos> ObtenerListadoCampoService(int id, Guid listado)
        {
            return await _listadoCamposRepository.ObtenerListadoCampoRepository(id,listado);
        }

        public async Task<IEnumerable<TblListadoCampos>> ObtenerListadoCamposService()
        {
            return await _listadoCamposRepository.ObtenerListadoCamposRepository();
        }
    }
}
