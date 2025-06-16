using MediatR;

namespace ClinicManager.Application.Patients.Commands.UpdatePatient
{
    public record UpdatePatientCommand(
        Guid Id,
        string Name,
        string Cpf,
        DateTime BirthDate,
        string? Email,
        string? Phone,
        string? BloodType,
        double Height,
        double Weight,
        string? Address
    ) : IRequest<Unit>;

}
