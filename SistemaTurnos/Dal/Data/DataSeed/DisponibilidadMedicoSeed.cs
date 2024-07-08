using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Entities;
using System.Reflection.Emit;

namespace SistemaTurnos.Dal.Data.DataSeed
{
    public class DisponibilidadMedicoSeed : IEntityTypeConfiguration<DisponibilidadMedico>
    {
        public void Configure(EntityTypeBuilder<DisponibilidadMedico> builder)
        {
            builder.HasData(


     new DisponibilidadMedico 
            { 
                Id = 1, 
                MedicoId = 1, 
                DiaSemanaId = 1, 
                StartTime = new TimeOnly(9, 0), 
                EndTime = new TimeOnly(12, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 2, 
                MedicoId = 1, 
                DiaSemanaId = 3, 
                StartTime = new TimeOnly(13, 0), 
                EndTime = new TimeOnly(16, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 3, 
                MedicoId = 2, 
                DiaSemanaId = 2, 
                StartTime = new TimeOnly(10, 0), 
                EndTime = new TimeOnly(14, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 4, 
                MedicoId = 3, 
                DiaSemanaId = 4, 
                StartTime = new TimeOnly(8, 0), 
                EndTime = new TimeOnly(12, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 5, 
                MedicoId = 3, 
                DiaSemanaId = 5, 
                StartTime = new TimeOnly(14, 0), 
                EndTime = new TimeOnly(18, 0) 
            }
        );
        }
    }
}
