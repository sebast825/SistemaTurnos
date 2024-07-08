using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dto.DisponibilidadMedico
{
    public class DisponibilidadMedicoResponseDTO
    {
        public string Medico { get; set; }
        public string DiaSemana { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
