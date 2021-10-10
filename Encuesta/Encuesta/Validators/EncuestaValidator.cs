using Encuesta.Controllers.Encuesta.DTO;
using FluentValidation;

namespace Encuesta.Validators
{
    public class EncuestaValidator : AbstractValidator<EncuestaDTO>
    {
        public EncuestaValidator() 
        {
            RuleFor(post => post.NombreEncuesta)
                    .NotNull()
                    .WithMessage("El nombre no puede ser nulo");

            RuleFor(post => post.Descripcion)
                    .NotNull()
                    .WithMessage("La descripcion no puede ser nula");
        }
    }
}
