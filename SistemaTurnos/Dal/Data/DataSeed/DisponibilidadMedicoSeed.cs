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
                MedicoId = 5, 
                DiaSemanaId = 1, 
                StartTime = new TimeSpan(9, 0, 0), 
                EndTime = new TimeSpan(12, 0, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 2, 
                MedicoId = 5, 
                DiaSemanaId = 3, 
                StartTime = new TimeSpan(13, 0, 0), 
                EndTime = new TimeSpan(16, 0, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 3, 
                MedicoId = 6, 
                DiaSemanaId = 2, 
                StartTime = new TimeSpan(10, 0, 0), 
                EndTime = new TimeSpan(14, 0, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 4, 
                MedicoId = 7, 
                DiaSemanaId = 4, 
                StartTime = new TimeSpan(8, 0, 0), 
                EndTime = new TimeSpan(12, 0, 0) 
            },
            new DisponibilidadMedico 
            { 
                Id = 5, 
                MedicoId = 7, 
                DiaSemanaId = 5, 
                StartTime = new TimeSpan(14, 0, 0), 
                EndTime = new TimeSpan(18, 0, 0) 
            }
        );
        }
    }
}
