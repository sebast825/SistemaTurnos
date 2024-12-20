using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dto.DisponibilidadMedico
{
    public class DisponibilidadMedicoUpdateeRequestDTO
    {
        public int id { get;set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
