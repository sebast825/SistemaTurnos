namespace SistemaTurnos.Dal.Entities
{
    public class DiaSemana : ClaseBase
    {
        public string Nombre {  get; set; }
    }
}

public enum DayOfWeekEnum
{
    None,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
};