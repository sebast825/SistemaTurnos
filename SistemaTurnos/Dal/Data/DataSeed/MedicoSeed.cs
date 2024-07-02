using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class MedicoSeed : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasData(
                new Medico
                {
                    Id = 5,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    FechaNacimiento = new DateTime(1980, 5, 20),
                    Telefono = "123456789",
                    NumeroDocumento = "DNI12345678",
                    Email = "juan.perez@ejemplo.com",
                    SexoId = 1, // Hombre
                    NumeroLicencia = "LIC1234",
                    EspecialidadId = 1, // Cardiología
                    FechaCreacion = DateTime.Now
                },
                new Medico
                {
                    Id = 6,
                    Nombre = "María",
                    Apellido = "González",
                    FechaNacimiento = new DateTime(1975, 3, 15),
                    Telefono = "987654321",
                    NumeroDocumento = "DNI87654321",
                    Email = "maria.gonzalez@ejemplo.com",
                    SexoId = 2, // Mujer
                    NumeroLicencia = "LIC5678",
                    EspecialidadId = 2, // Dermatología
                    FechaCreacion = DateTime.Now
                },
                new Medico
                {
                    Id = 7,
                    Nombre = "Carlos",
                    Apellido = "López",
                    FechaNacimiento = new DateTime(1985, 12, 10),
                    Telefono = "555123456",
                    NumeroDocumento = "DNI23456789",
                    Email = "carlos.lopez@ejemplo.com",
                    SexoId = 1, // Hombre
                    NumeroLicencia = "LIC9101",
                    EspecialidadId = 3, // Neurología
                    FechaCreacion = DateTime.Now
                }
            );
        }
    }
}
