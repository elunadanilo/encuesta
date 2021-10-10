using Encuesta.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encuesta.Interfaces
{
    public interface IListadoCamposService
    {
        Task<IEnumerable<TblListadoCampos>> ObtenerListadoCamposService();
        Task<TblListadoCampos> ObtenerListadoCampoService(int id, Guid listado);
        Task InsertarListadoCampoService(TblListadoCampos listado);
        Task<bool> ActualizarListadoCampoService(TblListadoCampos listado);
        Task<bool> EliminarListadoCampoService(int id, Guid listado);
        Task<TblListadoCampos> ObtenerListadoCampoEncuestaService(Guid listado);
    }
}
