namespace ClinicManager.Application.Patients.DTOs;

public class PatientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
