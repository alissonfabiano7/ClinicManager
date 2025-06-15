using AutoMapper;
using ClinicManager.Application.Patients.Commands.CreatePatient;
using ClinicManager.Application.Patients.DTOs;
using ClinicManager.Domain.Entities;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>();

        CreateMap<CreatePatientCommand, Patient>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.NormalizedName, opt => opt.Ignore());
    }
}
