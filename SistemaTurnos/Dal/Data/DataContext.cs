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
        }

        //Nombre de las  tablas
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Sexo> Sexos{ get; set; }

    }
}
