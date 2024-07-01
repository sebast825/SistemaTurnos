using Microsoft.EntityFrameworkCore;
using PatronRepositorio_UnitOfWork.Dal.Data.DataSeed;
using PatronRepositorio_UnitOfWork.Dal.Entities;
using System.Security;

namespace PatronRepositorio_UnitOfWork.Dal.Data
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
        }

        //Nombre de las  tablas
        public virtual DbSet<Persona> Personas { get; set; }
    }
}
