using FluentValidation;

namespace ClinicManager.Application.Patients.Commands.UpdatePatient;

public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("CPF is required.")
            .Length(11).WithMessage("CPF must be 11 digits.");

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Today).WithMessage("BirthDate must be in the past.");

        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.Phone)
            .MaximumLength(20).When(x => !string.IsNullOrWhiteSpace(x.Phone));
    }
}
