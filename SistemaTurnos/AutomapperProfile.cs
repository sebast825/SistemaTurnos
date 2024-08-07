using AutoMapper;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Administrativo;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Dto.Turno;

namespace SistemaTurnos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() {

            CreateMap<Paciente, PacienteResponseDTO>()
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo.Nombre)) // Asigna directamente la entidad Sexo
                    .ForMember(dest => dest.EstadoUsuario, opt => opt.MapFrom(src => src.EstadoPersona));

            CreateMap<PacienteCreateRequestDTO, Paciente>();
            //.ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => new Sexo { Id = src.SexoId }));

            CreateMap<Persona, PersonaResponseDTO>()
                 .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo.Nombre)) // Asigna directamente la entidad Sexo
                 .ForMember(dest => dest.EstadoUsuario, opt => opt.MapFrom(src => src.EstadoPersona));

            CreateMap<Medico, MedicoResponseDTO>()
             .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo.Nombre)) // Asigna directamente la entidad Sexo
                .ForMember(dest => dest.Especialidad, opt => opt.MapFrom(src => src.Especialidad.Nombre))
                   .ForMember(dest => dest.EstadoUsuario, opt => opt.MapFrom(src => src.EstadoPersona));
            CreateMap<MedicoCreateRequestDTO, Medico>();

            CreateMap<DisponibilidadMedico, DisponibilidadMedicoResponseDTO>()
                .ForMember(dest => dest.Medico, opt => opt.MapFrom(src => src.Medico.Nombre + " " + src.Medico.Apellido))
                .ForMember(dest => dest.DiaSemana, opt => opt.MapFrom(src => src.DiaSemana.Nombre))
                   .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(@"hh\:mm")))
                 .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm")));


            CreateMap<DisponibilidadMedicoCreateRequestDTO, DisponibilidadMedico>()
                    .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.StartTime)))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)));

            CreateMap<Turno, TurnoResponseDTO>()
                .ForMember(dest => dest.Medico, opt => opt.MapFrom(src => src.Medico.Nombre + " " + src.Medico.Apellido))
                .ForMember(dest => dest.Paciente, opt => opt.MapFrom(src => src.Paciente.Nombre + " " + src.Paciente.Apellido))
                .ForMember(dest => dest.PacienteDni, opt => opt.MapFrom(src => src.Paciente.NumeroDocumento))
                 .ForMember(dest => dest.Especialidad, opt => opt.MapFrom(src => src.Medico.Especialidad.Nombre));

            CreateMap<TurnoCreateRequestDTO, Turno>();


            CreateMap<AdministrativoRequestCreateDTO, Administrativo>();
            CreateMap<Administrativo, AdministrativoResponseDTO>();


        }

    }
}

/*
 {
  "medicoId": 5,
  "diaSemanaId": 5,
  "startTime": "11:20",
  "endTime": "13:40"
}

 */