using AutoMapper;
using ClinicManager.Domain.Entities;
using ClinicManager.Domain.Interfaces;
using MediatR;

namespace ClinicManager.Application.Patients.Commands.CreatePatient;

public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly IPatientRepository _repo;
    private readonly IMapper _mapper;

    public CreatePatientHandler(IPatientRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePatientCommand cmd, CancellationToken ct)
    {
        var patient = _mapper.Map<Patient>(cmd);

        await _repo.CreateAsync(patient, ct);

        return patient.Id;
    }
}
