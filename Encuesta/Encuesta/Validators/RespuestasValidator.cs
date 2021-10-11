using Encuesta.Controllers.CompletarEncuesta.DTO;
using Encuesta.Enums;
using FluentValidation;
using System;

namespace Encuesta.Validators
{
    public class RespuestasValidator : AbstractValidator<RespuestasEncuestaDTO>
    {
        public RespuestasValidator()
        {
            RuleFor(post => post.Respuesta)
            .NotNull()
            .WithMessage("La respuesta no puede ser nula");

            RuleFor(post => post.Requerido)
            .NotNull()
            .WithMessage("El tipo de campo requerido no puede ser nulo");

            RuleFor(x => x.TipoDeCampo)
            .IsEnumName(typeof(TipoCampo), caseSensitive: false)
            .WithMessage("El tipo de campo debe ser Texto, Fecha o Numero");

            RuleFor(x => x.Respuesta)
                .Custom((x, context) =>
                {
                        DateTime fecha;
                        var test = 0;
                        if (!int.TryParse(x, out test) || DateTime.TryParse(x, out fecha))
                        {
                            context.AddFailure($"{x} no es texto");
                        }
                })
                .When(x => x.TipoDeCampo.Equals("Texto"));

            RuleFor(x => x.Respuesta)
                .Custom((x, context) =>
                {
                        var test = 0;
                        if (!int.TryParse(x, out test))
                        {
                            context.AddFailure($"{x} no es numerico");
                        }
                })
                .When(x => x.TipoDeCampo.Equals("Numero"));

            RuleFor(x => x.Respuesta)
                .Custom((x, context) =>
                {
                        DateTime fecha;
                        if (!DateTime.TryParse(x, out fecha))
                        {
                            context.AddFailure($"{x} no es de tipo fecha");
                        }
                })
                .When(x => x.TipoDeCampo.Equals("Fecha"));
        }
    }
}
