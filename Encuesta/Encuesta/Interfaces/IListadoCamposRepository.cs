using Encuesta.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IListadoCamposRepository
    {
        Task<IEnumerable<TblListadoCampos>> ObtenerListadoCamposRepository();
        Task<TblListadoCampos> ObtenerListadoCampoRepository(int id, Guid listado);
        Task InsertarListadoCampoRepository(TblListadoCampos listado);
        Task<bool> ActualizarListadoCampoRepository(TblListadoCampos listado);
        Task<bool> EliminarListadoCampoRepository(int id, Guid listado);

        Task<TblListadoCampos> ObtenerListadoCampoEncuestaRepository(Guid listado);
    }
}
