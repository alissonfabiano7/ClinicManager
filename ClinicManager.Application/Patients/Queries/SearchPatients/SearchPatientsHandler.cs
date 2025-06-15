using AutoMapper;
using ClinicManager.Application.Patients.DTOs;
using ClinicManager.Domain.Interfaces;
using MediatR;

public class SearchPatientsHandler : IRequestHandler<SearchPatientsQuery, List<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public SearchPatientsHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<PatientDto>> Handle(SearchPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _repository.SearchAsync(request.search, cancellationToken);
        return _mapper.Map<List<PatientDto>>(patients);
    }
}
