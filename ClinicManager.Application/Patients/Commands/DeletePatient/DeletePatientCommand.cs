using MediatR;

namespace ClinicManager.Application.Patients.Commands.DeletePatient
{
    public record DeletePatientCommand(Guid Id) : IRequest<Unit>;
}
