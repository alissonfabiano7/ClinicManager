using AutoMapper;
using ClinicManager.Application.Patients.DTOs;
using ClinicManager.Application.Patients.Queries;
using ClinicManager.Domain.Interfaces;
using MediatR;

namespace ClinicManager.Application.Patients.Handlers;

public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetPatientByIdHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);
        if (patient == null)
            throw new Exception("Patient not found");

        return _mapper.Map<PatientDto>(patient);
    }
}
