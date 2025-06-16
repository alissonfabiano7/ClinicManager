using MediatR;

namespace ClinicManager.Application.Patients.Commands.CreatePatient;

public record CreatePatientCommand(
    string Name,
    string Cpf,
    DateTime BirthDate,
    string? Email,
    string? Phone,
    string? BloodType,
    double Height,
    double Weight,
    string? Address) : IRequest<Guid>;