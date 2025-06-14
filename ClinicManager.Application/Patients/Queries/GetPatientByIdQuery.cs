using ClinicManager.Application.Patients.DTOs;
using MediatR;

namespace ClinicManager.Application.Patients.Queries;

public record GetPatientByIdQuery(Guid Id) : IRequest<PatientDto>;
