using SistemaTurnos.Common;

namespace SistemaTurnos.Dal.Entities
{
    public class Usuario : ClaseBase
    {
        public Usuario(Role role = Role.Paciente) {
            Role = role;
            EstadoUsuario = EstadoUsuario.Activo;
            TokenRecovery = null;
        }    
        public string UserName { get;set; }
        public string Password { get;set; }
        
        public int? PersonaId { get; set; }
        public Persona Persona { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public EstadoUsuario EstadoUsuario { get; set; }

        public string? TokenRecovery{ get; set; }
    }
}
