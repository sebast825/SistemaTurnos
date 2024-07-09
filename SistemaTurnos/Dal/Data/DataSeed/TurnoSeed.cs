using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class TurnoSeed : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.HasData(
             new Turno
             {
                 Id = 1,
                 MedicoId = 5,
                 PacienteId = 3,
                 Fecha = DateTime.Now.AddDays(1),
                 Estado = EstadoTurno.Programada,
             },
             new Turno
             {
                 Id = 2,
                 MedicoId = 6,
                 PacienteId = 4,
                 Fecha = DateTime.Now.AddDays(2),
                 Estado = EstadoTurno.Cancelada,
             },
             new Turno
             {
                 Id = 3,
                 MedicoId = 7,
                 PacienteId = 3,
                 Fecha = DateTime.Now.AddDays(3),
                 Estado = EstadoTurno.Completada,
             },
             new Turno
             {
                 Id = 4,
                 MedicoId = 5,
                 PacienteId = 4,
                 Fecha = DateTime.Now.AddDays(4),
                 Estado = EstadoTurno.LLamando,
             },
             new Turno
             {
                 Id = 5,
                 MedicoId = 6,
                 PacienteId = 3,
                 Fecha = DateTime.Now.AddDays(5),
                 Estado = EstadoTurno.EnProgreso,
             },
             new Turno
             {
                 Id = 6,
                 MedicoId = 7,
                 PacienteId = 4,
                 Fecha = DateTime.Now.AddDays(6),
                 Estado = EstadoTurno.Finalizada,
             },
             new Turno
             {
                 Id = 7,
                 MedicoId = 5,
                 PacienteId = 3,
                 Fecha = DateTime.Now.AddDays(7),
                 Estado = EstadoTurno.NoAsistida,
             }
         );
        }
    }
}
