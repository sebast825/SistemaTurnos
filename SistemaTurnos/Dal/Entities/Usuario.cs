namespace SistemaTurnos.Dal.Entities
{
    public class Usuario : ClaseBase
    {
        public string UserName { get;set; }
        public string Password { get;set; }
        
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

    }
}
