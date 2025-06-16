using FluentValidation;

namespace ClinicManager.Application.Patients.Commands.CreatePatient;

public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(120);

        RuleFor(x => x.Cpf).NotEmpty().Length(11);

        RuleFor(x => x.BirthDate).LessThan(DateTime.Today);

        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.Phone).MaximumLength(20).When(x => !string.IsNullOrWhiteSpace(x.Phone));

        RuleFor(x => x.BloodType).MaximumLength(3).When(x => !string.IsNullOrWhiteSpace(x.BloodType));

        RuleFor(x => x.Height).GreaterThan(0).WithMessage("Height must be greater than 0.");

        RuleFor(x => x.Weight).GreaterThan(0).WithMessage("Weight must be greater than 0.");

        RuleFor(x => x.Address).MaximumLength(200).When(x => !string.IsNullOrWhiteSpace(x.Address));

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
    }
}
