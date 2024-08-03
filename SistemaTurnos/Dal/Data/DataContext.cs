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
            //modelBuilder.ApplyConfiguration(new RolSeed());
            //modelBuilder.ApplyConfiguration(new EstadoUsuarioSeed());
            modelBuilder.ApplyConfiguration(new DiaSemanaSeed());
            modelBuilder.ApplyConfiguration(new DisponibilidadMedicoSeed());
            modelBuilder.ApplyConfiguration(new TurnoSeed());

            // Configuración específica para la entidad Turno
            modelBuilder.Entity<Turno>()
                .Property(t => t.Estado) // Selecciona la propiedad 'Estado' en la entidad 'Turno'
                .HasConversion( // Define una conversión personalizada para esta propiedad
                    v => v.ToString(), // Conversión de la propiedad 'Estado' del enum a string al guardar en la base de datos
                    v => (EstadoTurno)Enum.Parse(typeof(EstadoTurno), v) // Conversión de string a enum 'EstadoTurno' al leer de la base de datos
                );

            //en caso de que se eliminen datos no afecta la consistencia de datos
            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasOne(t => t.Medico)
                    .WithMany()
                    .HasForeignKey(t => t.MedicoId)
                    .OnDelete(DeleteBehavior.NoAction);
                //en caso de que se eliminen datos no afecta la consistencia de datos

                entity.HasOne(t => t.Paciente)
                    .WithMany()
                    .HasForeignKey(t => t.PacienteId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.ApplyConfiguration(new UsuarioSeed());

            //convierte los enums en enteros para la db, se pueden realizar consultas de manera comun
         /*   {
                modelBuilder.Entity<Persona>()
                    .Property(p => p.EstadoPersona)
                    .HasConversion<int>();
                modelBuilder.Entity<Usuario>()
                  .Property(p => p.EstadoUsuario)
                  .HasConversion<int>();
            }*/
        }

        //Nombre de las  tablas
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Sexo> Sexos{ get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        //public virtual DbSet<Rol> Roles { get; set; }
       // public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; }
        public virtual DbSet<DiaSemana> DiasSemana { get; set; }
        public virtual DbSet<DisponibilidadMedico> DisponibilidadMedicos{ get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Administrativo> Administrativos{ get; set; }
        
        public DbSet<Turno> Turnos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }



    }
}
