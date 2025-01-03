using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTurnos.Dal.Entities;

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
                       Telefono = "123456789",
                       NumeroDocumento = "12345678",
                       SexoId = 1 // Hombre
                   },
            new Persona
            {
                Id = 2,
                Nombre = "María",
                Apellido = "Gómez",
                FechaNacimiento = new DateTime(1990, 8, 15),
                Telefono = "987654321",
                NumeroDocumento = "87654321",
                SexoId = 2 // Mujer
            }
            );
        }
    }
}