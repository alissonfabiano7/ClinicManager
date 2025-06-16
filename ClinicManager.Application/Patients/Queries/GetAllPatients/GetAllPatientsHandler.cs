using AutoMapper;
using ClinicManager.Application.Exceptions;
using ClinicManager.Application.Patients.DTOs;
using ClinicManager.Domain.Interfaces;
using MediatR;

namespace ClinicManager.Application.Patients.Queries.GetAllPatients;

public class GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery, List<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetAllPatientsHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _repository.GetAllAsync(request.Page, request.PageSize, cancellationToken);
        if (patients is null || !patients.Any())
            throw new NotFoundException(nameof(patients),"No patients found");

        return _mapper.Map<List<PatientDto>>(patients);
    }
}
