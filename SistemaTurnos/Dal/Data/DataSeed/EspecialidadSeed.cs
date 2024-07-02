using SistemaTurnos.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaTurnos.Dal.Data.DataSeed 
{
    public class EspecialidadSeed : IEntityTypeConfiguration<Especialidad>
    { 
        public void Configure(EntityTypeBuilder<Especialidad> builder) { 
            builder.HasData(
                new Especialidad
                {
                    Id = 1,
                    Nombre = "Cardiología",
                    Descripcion = "Especialidad médica que se ocupa del estudio, diagnóstico y tratamiento de las enfermedades del corazón y del sistema circulatorio."
                },
                new Especialidad
                {
                    Id = 2,
                    Nombre = "Dermatología",
                    Descripcion = "Especialidad médica que se encarga del estudio de la piel, su estructura, función y enfermedades."
                },
                new Especialidad
                {
                    Id = 3,
                    Nombre = "Neurología",
                    Descripcion = "Especialidad médica que se encarga del estudio, diagnóstico y tratamiento de las enfermedades del sistema nervioso."
                }
            );
        }
    }
}
