using ClinicManager.Application.Patients.DTOs;
using MediatR;

public record SearchPatientsQuery(string search) : IRequest<List<PatientDto>>;
