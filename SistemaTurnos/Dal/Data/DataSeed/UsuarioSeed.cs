using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTurnos.Common;
using SistemaTurnos.Dal.Entities;

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
                    PersonaId = 1,
                    Email = "persona@example.com",
                    Role = Role.Paciente,
                                EstadoUsuario = EstadoUsuario.Activo

                },
                new Usuario
                {
                    Id = 2,
                    UserName = "paciente",
                    Password = "a",
                    PersonaId = 3,
                    Email = "paciente@example.com",
                    Role = Role.Paciente,
                                EstadoUsuario = EstadoUsuario.Activo
                },
                new Usuario
                {
                    Id = 3,
                    UserName = "medico",
                    Password = "a",
                    PersonaId = 5,
                    Email = "medico@example.com",
                    Role = Role.Medico,
                                EstadoUsuario = EstadoUsuario.Activo
                },
                new Usuario
                {
                    Id = 4,
                    UserName = "secretario",
                    Password = "a",
                    PersonaId = 8,
                    Email = "secretario@example.com",
                    Role = Role.Secretario,
                                EstadoUsuario = EstadoUsuario.Activo
                },
                new Usuario
                {
                    Id = 5,
                    UserName = "admin",
                    Password = "a",
                    PersonaId = 9,
                    Email = "admin@example.com",
                    Role = Role.Admin,
                                EstadoUsuario = EstadoUsuario.Activo
                }
            });
        }
    }
}
