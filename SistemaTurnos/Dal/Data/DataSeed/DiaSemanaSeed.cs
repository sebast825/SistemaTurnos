using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class DiaSemanaSeed : IEntityTypeConfiguration<DiaSemana>
    {
        public void Configure(EntityTypeBuilder<DiaSemana> builder)
        {
            builder.HasData(new DiaSemana
            {
                Id = 1,
                Nombre = "Lunes"

            },
            new DiaSemana
            {
                Id = 2,
                Nombre = "Martes"

            },
            new DiaSemana
            {
                Id = 3,
                Nombre = "Miércoles"

            }, new DiaSemana
            {
                Id = 4,
                Nombre = "Jueves"

            },
            new DiaSemana
            {
                Id = 5,
                Nombre = "Viernes"

            },
            new DiaSemana
            {
                Id = 6,
                Nombre = "Sábado"

            }, new DiaSemana
            {
                Id = 7,
                Nombre = "Domingo"

            });
        }
    }
}
