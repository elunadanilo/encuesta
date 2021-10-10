using AutoMapper;
using Encuesta.Controllers.CompletarEncuesta.DTO;
using Encuesta.Controllers.Encuesta.DTO;
using Encuesta.Controllers.ListadoCampos.DTO;
using Encuesta.Data;

namespace Encuesta.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TblEncuesta, EncuestaDTO>();
            CreateMap<EncuestaDTO, TblEncuesta>();

            CreateMap<TblListadoCampos, ListadoCamposDTO>();
            CreateMap<ListadoCamposDTO, TblListadoCampos>();

            CreateMap<TblListadoCampos, PreguntasEncuestaDTO>();
            CreateMap<PreguntasEncuestaDTO, TblListadoCampos>();

            CreateMap<TblRespuestas, RespuestasEncuestaDTO>();
            CreateMap<RespuestasEncuestaDTO, TblRespuestas>();
        }
    }
}
