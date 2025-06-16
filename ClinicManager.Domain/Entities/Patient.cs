using System;
using ClinicManager.Application.Common.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManager.Domain.Entities;

public class Patient
{
    private string _name = "";

    public Guid Id { get; set; }
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            NormalizedName = TextNormalizer.Normalize(value);
        }
    }
    public string NormalizedName { get; private set; } = "";
    public string Cpf { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? BloodType { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string? Address { get; set; }
}