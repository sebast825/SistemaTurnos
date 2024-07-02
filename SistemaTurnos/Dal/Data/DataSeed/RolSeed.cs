using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class RolSeed : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(new Rol
            {
                Id = 1,
                Nombre = "Admin"

            },
            new Rol
            {
                Id = 2,
                Nombre = "Secretario"

            }
            );
    
        }
    }
}





