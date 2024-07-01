using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Entities
{
    public class Persona : ClaseBase
    {
        public Persona() { 
            FechaCreacion = DateTime.Now;
        }
        public string Nombre {get;set;}
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public int NumeroDocumento { get; set; }
        public string Email { get; set; }
        public int SexoId { get; set; }

        public Sexo Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
