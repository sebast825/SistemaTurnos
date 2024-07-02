using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Data.DataSeed;
using SistemaTurnos.Dal.Entities;
using System.Security;

namespace SistemaTurnos.Dal.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)

        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonaSeed());
            modelBuilder.ApplyConfiguration(new SexoSeed());
            modelBuilder.Entity<Persona>(entity =>
            {
                // Mapeo de FechaCreacion a la columna date en SQL Server (no se guarda la hora)
                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date");
            });
            modelBuilder.ApplyConfiguration(new PacienteSeed());
            modelBuilder.ApplyConfiguration(new MedicoSeed());
            modelBuilder.ApplyConfiguration(new EspecialidadSeed());


        }

        //Nombre de las  tablas
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Sexo> Sexos{ get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }

        /*
        public virtual DbSet<Administrativo> Administrativos { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }*/





    }
}
