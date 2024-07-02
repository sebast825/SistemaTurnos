namespace SistemaTurnos.Dal.Entities
{
    public class Paciente : Persona
    {
        public Paciente() : base() // Llama al constructor de la clase base
        {
        }
        public string TelefonoEmergencia { get; set; }
        public string NombreEmergencia { get; set; }

    }
}
