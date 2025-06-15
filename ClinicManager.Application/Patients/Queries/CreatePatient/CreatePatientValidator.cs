using FluentValidation;

namespace ClinicManager.Application.Patients.Commands.CreatePatient;

public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(120);
        RuleFor(x => x.Cpf).NotEmpty().Length(11);
        RuleFor(x => x.BirthDate).LessThan(DateTime.Today);
    }
}
