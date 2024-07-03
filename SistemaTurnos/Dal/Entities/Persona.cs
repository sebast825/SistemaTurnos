using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Entities
{
    public class Persona : ClaseBase
    {
        public Persona() : base() { 
            FechaCreacion = DateTime.Now;
            EstadoUsuarioId = 1;
        }
        public string Nombre {get;set;}
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public int SexoId { get; set; }

        public Sexo Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int EstadoUsuarioId { get; set; }

        public EstadoUsuario EstadoUsuario { get; set; }

    }
}
