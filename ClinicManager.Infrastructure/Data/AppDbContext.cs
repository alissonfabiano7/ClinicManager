using ClinicManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
}
