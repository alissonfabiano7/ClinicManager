using ClinicManager.Domain.Entities;

namespace ClinicManager.Domain.Interfaces;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid id);
    Task<List<Patient>> SearchAsync(string search, CancellationToken ct);
    Task<List<Patient>> GetAllAsync(int page, int pageSize, CancellationToken ct);
    Task CreateAsync(Patient patient, CancellationToken ct);
    Task UpdateAsync(Patient patient, CancellationToken ct);
    Task DeleteAsync(Patient patient, CancellationToken ct);
}
