namespace SistemaTurnos.Dal.Entities
{
    public class Administrativo : Persona
    {
        public int RolId { get; set; }

        public  Rol Rol {get;set;}
    }
}
