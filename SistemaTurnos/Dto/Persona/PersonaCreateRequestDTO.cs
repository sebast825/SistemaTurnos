namespace SistemaTurnos.Dto.Persona
{
    public class PersonaCreateRequestDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string NumeroDocumento { get; set; }
        public int SexoId { get; set; }

    }
}
