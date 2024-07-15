using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class UsuarioSeed : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                UserName = "persona",
                Password = "a",
                PersonaId = 1
            },
            new Usuario
            {
                Id = 2,
                UserName = "paciente",
                Password = "a",
                PersonaId = 3
            },
            new Usuario
            {
                Id = 3,
                UserName = "medico",
                Password = "a",
                PersonaId = 5
            },
            new Usuario
            {
                Id = 4,
                UserName = "secretario",
                Password = "a",
                PersonaId = 8
            },
            new Usuario
            {
                Id = 5,
                UserName = "admin",
                Password = "a",
                PersonaId = 9
            }

        });
            
        }
    }
}





