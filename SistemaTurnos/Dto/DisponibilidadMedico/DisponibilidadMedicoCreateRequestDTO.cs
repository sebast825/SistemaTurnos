using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dto.DisponibilidadMedico
{
    public class DisponibilidadMedicoCreateRequestDTO
    {
        public int MedicoId { get; set; }
        public int DiaSemanaId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
