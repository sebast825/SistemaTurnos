using Microsoft.AspNetCore.Identity;
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonaSeed());
            modelBuilder.ApplyConfiguration(new SexoSeed());
            modelBuilder.Entity<Persona>(entity =>
            {
                // Mapeo de FechaCreacion a la columna date en SQL Server (no se guarda la hora)
                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date");
            });
            // Configuración de la herencia con discriminador
         

            modelBuilder.ApplyConfiguration(new PacienteSeed());
            modelBuilder.ApplyConfiguration(new MedicoSeed());
            modelBuilder.ApplyConfiguration(new EspecialidadSeed());
            modelBuilder.ApplyConfiguration(new AdministrativoSeed());
            modelBuilder.ApplyConfiguration(new RolSeed());
            modelBuilder.ApplyConfiguration(new EstadoUsuarioSeed());
            modelBuilder.ApplyConfiguration(new DiaSemanaSeed());
            modelBuilder.ApplyConfiguration(new DisponibilidadMedicoSeed());

            //convierte el tipo de dato TimeOnly
            /*    modelBuilder.Entity<DisponibilidadMedico>()
           .Property(p => p.StartTime)
           .HasConversion(
               v => v.ToTimeSpan(),
               v => new TimeOnly(v.Ticks)
           );

                modelBuilder.Entity<DisponibilidadMedico>()
                    .Property(p => p.EndTime)
                    .HasConversion(
                        v => v.ToTimeSpan(),
                        v => new TimeOnly(v.Ticks)
                    );*/
            /*
            modelBuilder.ApplyConfiguration(new DisponibilidadMedicoSeed());

            modelBuilder.Entity<Persona>()
             .HasDiscriminator<int>("Type")
             .HasValue<Persona>(0)
             .HasValue<Medico>(1)
                          .HasValue<Paciente>(2)
                                      .HasValue<Administrativo>(3);

            */
        }

        //Nombre de las  tablas
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Sexo> Sexos{ get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; }
        public virtual DbSet<DiaSemana> DiasSemana { get; set; }
        public virtual DbSet<DisponibilidadMedico> DisponibilidadMedicos{ get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Administrativo> Administrativos{ get; set; }





    }
}
