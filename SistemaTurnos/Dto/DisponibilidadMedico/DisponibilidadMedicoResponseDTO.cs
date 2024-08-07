using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dto.DisponibilidadMedico
{
    public class DisponibilidadMedicoResponseDTO
    {
        public int Id { get; set; }

        public string Medico { get; set; }
        public string DiaSemana { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
