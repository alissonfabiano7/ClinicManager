using ClinicManager.Application.Patients.DTOs;
using MediatR;

namespace ClinicManager.Application.Patients.Queries.SearchPatients;

public record SearchPatientsQuery(string search) : IRequest<List<PatientDto>>;
