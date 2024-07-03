using AutoMapper;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() {

            CreateMap<Paciente, PacienteResponseDTO>()
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo.Nombre)) // Asigna directamente la entidad Sexo
                    .ForMember(dest => dest.EstadoUsuario, opt => opt.MapFrom(src => src.EstadoUsuario.Nombre));
            CreateMap<PacienteCreateRequestDTO, Paciente>();
           //.ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => new Sexo { Id = src.SexoId }));
        
    }
    }
}
