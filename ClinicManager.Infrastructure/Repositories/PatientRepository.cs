﻿using ClinicManager.Domain.Entities;
using ClinicManager.Domain.Interfaces;
using ClinicManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _context;

    public PatientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Patient>> SearchAsync(string search, CancellationToken ct)
    {
        var query = _context.Patients.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p =>
                p.NormalizedName.Contains(search) ||
                p.Cpf.Contains(search)
            );
        }

        return await query.ToListAsync(ct);
    }

    public async Task<List<Patient>> GetAllAsync(int page, int pageSize, CancellationToken ct)
    {
        return await _context.Patients
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task CreateAsync(Patient patient, CancellationToken ct)
    {
        await _context.Patients.AddAsync(patient, ct);
        await _context.SaveChangesAsync(ct);
    }

    public Task UpdateAsync(Patient patient, CancellationToken ct)
    {
        _context.Patients.Update(patient);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Patient patient, CancellationToken ct)
    {
        _context.Patients.Remove(patient);
        return Task.CompletedTask;
    }
}
