using Encuesta.Controllers.ListadoCampos.DTO;
using Encuesta.Enums;
using FluentValidation;

namespace Encuesta.Validators
{
    public class ListadoCamposValidator : AbstractValidator<ListadoCamposDTO>
    {
        public ListadoCamposValidator() 
        {
            RuleFor(x => x.TipoDeCampo).IsEnumName(typeof(TipoCampo), caseSensitive: false).WithMessage("El tipo de campo debe ser Texto, Fecha o Numero");
        }
    }
}
