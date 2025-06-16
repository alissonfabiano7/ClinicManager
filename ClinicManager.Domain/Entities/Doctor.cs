namespace ClinicManager.Domain.Entities;
public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string BloodType { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string Specialty { get; set; } = string.Empty;
    public string CRM { get; set; } = string.Empty;
}
