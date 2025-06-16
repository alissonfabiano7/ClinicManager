using ClinicManager.Application.Exceptions;
using ClinicManager.Domain.Entities;
using ClinicManager.Domain.Interfaces;
using MediatR;

namespace ClinicManager.Application.Patients.Commands.DeletePatient;

public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, Unit>
{
    private readonly IPatientRepository _repository;

    public DeletePatientHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeletePatientCommand cmd, CancellationToken ct)
    {
        var patient = await _repository.GetByIdAsync(cmd.Id);

        if (patient is null)
            throw new NotFoundException(nameof(patient), cmd.Id);

        await _repository.DeleteAsync(patient, ct);

        return Unit.Value;
    }
}
