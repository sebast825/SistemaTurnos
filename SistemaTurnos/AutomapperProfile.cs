using AutoMapper;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Paciente;

namespace SistemaTurnos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() {

            CreateMap<Paciente, PacienteResponseDTO>()
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo.Nombre)); // Asigna directamente la entidad Sexo

        }
    }
}
