﻿namespace SistemaTurnos.Dto.Persona
{
    public class PersonaResponseDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string EstadoUsuario { get; set; }
    }
}
