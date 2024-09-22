// Services/Validators/DTOAppointmentValidator.cs
using FluentValidation;
using Services.DTO;

namespace Services.Validators
{
    public class DTOAppointmentValidator : AbstractValidator<DTOAppointment>
    {
        public DTOAppointmentValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .Length(5, 100).WithMessage("La descripción debe tener entre 5 y 100 caracteres.");

            RuleFor(x => x.Date)
                .GreaterThan(DateTime.Now).WithMessage("La fecha de la cita debe ser en el futuro.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("El nombre del cliente no puede estar vacío.")
                .Length(2, 50).WithMessage("El nombre del cliente debe tener entre 2 y 50 caracteres.");

            RuleFor(x => x.ServiceId)
                .GreaterThan(0).WithMessage("Debe seleccionar un servicio válido.");
        }
    }
}
