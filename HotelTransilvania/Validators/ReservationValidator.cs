using Commom.DTOs;
using FluentValidation;
using System;

namespace HotelTransilvania.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationDTO>
    {
        public ReservationValidator()
        {
            RuleFor(_ => _.MainGuestId)
                .NotEmpty()
                .WithMessage("Nome do hóspede é obrigatório.");

            RuleFor(_ => _.RoomCategoryId)
                .NotEmpty()
                .WithMessage("Selecione a categoria.");

            RuleFor(_ => _.RoomId)
                .NotEmpty()
                .WithMessage("Selecione o apartamento.");

            RuleFor(_ => _.Arrival)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Data de CheckIn não pode ser anterior a data atual.")
                .NotEmpty()
                .WithMessage("Data de CheckIn é obrigatória.");

            RuleFor(_ => _.Departure)
                .GreaterThan(_=>_.Arrival)
                 .WithMessage("Data de Checkout deve ser posterior ao dia de CheckIn.")
                .NotEmpty()
                .WithMessage("Data de CheckOut é obrigatória.");

            RuleFor(_ => _.ContactPersonId)
               .NotEmpty()
               .WithMessage("Nome do contato é obrigatório.");
        }
    }
}
