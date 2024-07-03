using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class EstadoUsuarioSeed : IEntityTypeConfiguration<EstadoUsuario>
    {
        public void Configure(EntityTypeBuilder<EstadoUsuario> builder)
        {
            builder.HasData(new EstadoUsuario
            {
                Id = 1,
                Nombre = "Activo"

            },
            new EstadoUsuario
            {
                Id = 2,
                Nombre = "Inactivo"

            },
            new EstadoUsuario
            {
                Id = 3,
                Nombre = "Suspendido"

            },
            new EstadoUsuario
            {
                Id = 4,
                Nombre = "Eliminado"

            });
        }
    }
}





