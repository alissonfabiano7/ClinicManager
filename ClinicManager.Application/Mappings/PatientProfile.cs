using AutoMapper;
using ClinicManager.Application.Patients.DTOs;
using ClinicManager.Domain.Entities;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>();
    }
}
