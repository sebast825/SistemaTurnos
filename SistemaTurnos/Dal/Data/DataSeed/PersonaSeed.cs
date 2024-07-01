using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class PersonaSeed : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasData(
                new Persona
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    FechaNacimiento = new DateTime(1985, 5, 10),
                    Telefono = 123456789,
                    NumeroDocumento = 12345678,
                    Email = "juan.perez@example.com",
                    SexoId = 1 // Hombre
                },
                new Persona
                {
                    Id = 2,
                    Nombre = "María",
                    Apellido = "Gómez",
                    FechaNacimiento = new DateTime(1990, 8, 15),
                    Telefono = 987654321,
                    NumeroDocumento = 87654321,
                    Email = "maria.gomez@example.com",
                    SexoId = 2 // Mujer
                },
                new Persona
                {
                    Id = 3,
                    Nombre = "Pedro",
                    Apellido = "Rodríguez",
                    FechaNacimiento = new DateTime(1988, 3, 25),
                    Telefono = 456789123,
                    NumeroDocumento = 56781234,
                    Email = "pedro.rodriguez@example.com",
                    SexoId = 1 // Hombre
                },
                new Persona
                {
                    Id = 4,
                    Nombre = "Ana",
                    Apellido = "Martínez",
                    FechaNacimiento = new DateTime(1995, 10, 5),
                    Telefono = 654321789,
                    NumeroDocumento = 34567812,
                    Email = "ana.martinez@example.com",
                    SexoId = 2 // Mujer
                },
                new Persona
                {
                    Id = 5,
                    Nombre = "Lucas",
                    Apellido = "Gutiérrez",
                    FechaNacimiento = new DateTime(1987, 7, 12),
                    Telefono = 789123456,
                    NumeroDocumento = 78123456,
                    Email = "lucas.gutierrez@example.com",
                    SexoId = 1 // Hombre
                },
                new Persona
                {
                    Id = 6,
                    Nombre = "Laura",
                    Apellido = "López",
                    FechaNacimiento = new DateTime(1993, 4, 20),
                    Telefono = 321654987,
                    NumeroDocumento = 23456781,
                    Email = "laura.lopez@example.com",
                    SexoId = 2 // Mujer
                },
                new Persona
                {
                    Id = 7,
                    Nombre = "Gabriel",
                    Apellido = "Sánchez",
                    FechaNacimiento = new DateTime(1986, 9, 8),
                    Telefono = 896745231,
                    NumeroDocumento = 67812345,
                    Email = "gabriel.sanchez@example.com",
                    SexoId = 1 // Hombre
                },
                new Persona
                {
                    Id = 8,
                    Nombre = "Carolina",
                    Apellido = "Fernández",
                    FechaNacimiento = new DateTime(1991, 6, 30),
                    Telefono = 478512369,
                    NumeroDocumento = 45678123,
                    Email = "carolina.fernandez@example.com",
                    SexoId = 2 // Mujer
                },
                new Persona
                {
                    Id = 9,
                    Nombre = "Jorge",
                    Apellido = "Díaz",
                    FechaNacimiento = new DateTime(1989, 2, 15),
                    Telefono = 369874512,
                    NumeroDocumento = 56781234,
                    Email = "jorge.diaz@example.com",
                    SexoId = 1 // Hombre
                },
                new Persona
                {
                    Id = 10,
                    Nombre = "Valeria",
                    Apellido = "Ramírez",
                    FechaNacimiento = new DateTime(1994, 11, 18),
                    Telefono = 214365879,
                    NumeroDocumento = 67812345,
                    Email = "valeria.ramirez@example.com",
                    SexoId = 2 // Mujer
                },
                   new Persona
                   {
                       Id = 11,
                       Nombre = "Valeria",
                       Apellido = "Ramírez",
                       FechaNacimiento = new DateTime(1993, 11, 18),
                       Telefono = 214365879,
                       NumeroDocumento = 67812345,
                       Email = "valeria.ramirez@example.com",
                       SexoId = 2 // Mujer
                   }
            );
        }
    }
}