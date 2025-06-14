using BookingService.Application.Bookings.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Bookings.Validators
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("El nombre del cliente es obligatorio.")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres.");

            RuleFor(x => x.VehicleId)
                .NotEmpty().WithMessage("El ID del vehículo es obligatorio.");

            RuleFor(x => x.StartDate)
                .Must(BeInThePresentOrFuture).WithMessage("La fecha de inicio debe ser hoy o en el futuro.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("La fecha de fin debe ser mayor a la fecha de inicio.")
                .Must(BeInThePresentOrFuture).WithMessage("La fecha de fin debe ser hoy o en el futuro.");

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("El precio total debe ser mayor que cero.");
        }

        private bool BeInThePresentOrFuture(DateTime date) =>
            date.Date >= DateTime.UtcNow.Date;
    }
}
