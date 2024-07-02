using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class PacienteSeed : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasData(
                new Paciente
                {
                    Id = 3,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    FechaNacimiento = new DateTime(1985, 5, 10),
                    Telefono = "123452389",
                    NumeroDocumento = "45345678",
                    Email = "juan.perez@example.com",
                    SexoId = 1, // Hombre
                    TelefonoEmergencia = "1122334455",

                    NombreEmergencia = "Ana Pérez"
                },
                new Paciente
                {
                   Id = 4,
                    Nombre = "María",
                    Apellido = "Gómez",
                    FechaNacimiento = new DateTime(1990, 8, 15),
                    Telefono = "123456756",
                    NumeroDocumento = "12345678",
                    Email = "maria.gomez@example.com",
                    SexoId = 2, // Mujer
                    TelefonoEmergencia = "2233445566",
                    NombreEmergencia = "Carlos Gómez"
                }
                
            );
        }
}
}