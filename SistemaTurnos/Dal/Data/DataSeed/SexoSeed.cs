using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class SexoSeed : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.HasData(new Sexo
            {
                Id = 1,
                Nombre = "Hombre"

            },
            new Sexo
            {
                Id = 2,
                Nombre = "Mujer"

            },
            new Sexo
            {
                Id = 3,
                Nombre = "Otro"

            });
        }
    }
}





