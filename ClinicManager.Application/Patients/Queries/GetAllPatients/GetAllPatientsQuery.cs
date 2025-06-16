using ClinicManager.Application.Patients.DTOs;
using MediatR;

namespace ClinicManager.Application.Patients.Queries.GetAllPatients;

public record GetAllPatientsQuery(int Page = 1, int PageSize = 20) : IRequest<List<PatientDto>>;