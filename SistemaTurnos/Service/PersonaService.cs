using AutoMapper;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PersonaResponseDTO> ActualizarEstado(int id, EstadoPersona estado)
        {




            var persona = await _unitOfWork.PersonaRepository.GetId(id);
            if (persona != null)
            {

                persona.EstadoPersona = estado;
                await _unitOfWork.Save();
                return _mapper.Map<PersonaResponseDTO>(persona);
            }

            throw new Exception("no se encontro");


        }
        /*
         public async Task<PersonaResponseDTO> ActualizarEstadoEliminar(int id)
         {

             var persona = await _unitOfWork.PersonaRepository.GetId(id);
             if (persona != null)
             {

                 persona.EstadoUsuarioId = 4;
                 persona.EstadoUsuario = await _unitOfWork.EstadoUsuarioRepository.GetId(4);
                 await _unitOfWork.Save();
                 return _mapper.Map<PersonaResponseDTO>(persona);
             }

             throw new Exception("no se encontro el usuario");
         }
        */
        public async Task<PersonaResponseDTO> ActualizarPersona(int id, PersonaUpdateRequestDTO dto)
        {


            var persona = await _unitOfWork.PersonaRepository.GetId(id);
            if (persona != null)
            {



                persona.Nombre = dto.Nombre;
                persona.Apellido = dto.Apellido;
                persona.FechaNacimiento = dto.FechaNacimiento;
                persona.NumeroDocumento = dto.NumeroDocumento;
                persona.Telefono = dto.Telefono;
                persona.SexoId = dto.SexoId;

                //una vez actualizados los datos se validan
                persona.ValidarAtributos();

                await _unitOfWork.Save();
                var personaUpdated = await _unitOfWork.PersonaRepository.GetId(id);

                return _mapper.Map<PersonaResponseDTO>(personaUpdated);
            }


            throw new Exception("an error ocurred");
        }

        public async Task<string> GetTipoPersona(int id)
        {
            var persona = await _unitOfWork.PersonaRepository.GetId(id);

            //switch(persona)
            //{
            //    case persona is Medico:
            //        return "Medico";
            //}
            return "Asd";
        }
        public async Task<PersonaResponseDTO> GetById(int id)
        {

            var persona = await _unitOfWork.PersonaRepository.GetId(id);
            var rsta = _mapper.Map<PersonaResponseDTO>(persona);

            return rsta;


        }

        public async Task<List<PersonaResponseDTO>> GetAllPersonaIncludeInactive()
        {
            var personas = await _unitOfWork.PersonaRepository.GetAllIncludeInactive();
            var rsta = _mapper.Map<List<PersonaResponseDTO>>(personas);

            return rsta;
        }
    }
}
