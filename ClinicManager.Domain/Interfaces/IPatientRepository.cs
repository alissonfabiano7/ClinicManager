using ClinicManager.Domain.Entities;

namespace ClinicManager.Domain.Interfaces;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid id);
    Task<List<Patient>> SearchAsync(string search, CancellationToken cancellationToken);
}
