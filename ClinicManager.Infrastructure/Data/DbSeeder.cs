using ClinicManager.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManager.Infrastructure.Data;

public static class DbSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (!context.Patients.Any())
        {
            context.Patients.AddRange([
                new Patient {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Maria da Silva",
                    Cpf = "12345678901",
                    BirthDate = new DateTime(1985, 6, 12),
                    Email = "maria@example.com",
                    Phone = "11999999999"
                },
                new Patient {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "João Pereira",
                    Cpf = "10987654321",
                    BirthDate = new DateTime(1990, 3, 24),
                    Email = "joao@example.com",
                    Phone = "11888888888"
                }
            ]);

            context.SaveChanges();
        }
    }
}
