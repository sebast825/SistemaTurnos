namespace SistemaTurnos.Dal.Entities
{
    public class Medico : Persona
    {
        public string NumeroLicencia { get; set; }
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}
