using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Service.Interface;
using System.ComponentModel.DataAnnotations;

namespace SistemaTurnos.Service
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonaService(IUnitOfWork unitOfWork, IMapper mapper) { 
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PersonaResponseDTO> ActualizarEstado(int id, EstadoPersona estado)
        {

            
          

            var persona = await _unitOfWork.PersonaRepository.GetId(id);
            if(persona != null) {

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

            ValidateNombre(dto.Nombre);
            ValidateApellido(dto.Apellido);
            ValidateFechaNac(dto.FechaNacimiento);
            await ValidateNumeroDocumento(dto.NumeroDocumento, id);
            ValidateSexoId(dto.SexoId);
            ValidateTelefono(dto.Telefono);
             var persona = await _unitOfWork.PersonaRepository.GetId(id);
            if (persona != null)
            {
                persona.Nombre = dto.Nombre;
                persona.Apellido = dto.Apellido;
                persona.FechaNacimiento = dto.FechaNacimiento;
                persona.NumeroDocumento = dto.NumeroDocumento;
                persona.Telefono = dto.Telefono;
                persona.SexoId = dto.SexoId;
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

        private void ValidateNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ValidationException("El nombre no puede estar vacío.");
            }
            if (nombre.Length > 100) // Asumiendo un máximo de 100 caracteres
            {
                throw new ValidationException("El nombre no puede exceder los 100 caracteres.");
            }
           
        }
        private void ValidateApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ValidationException("El apellido no puede estar vacío.");
            }
            if (apellido.Length > 100)
            {
                throw new ValidationException("El apellido no puede exceder los 100 caracteres.");
            }
        }

        private void ValidateFechaNac(DateTime fechaNac)
        {

            if (fechaNac > DateTime.Now)
            {
                throw new ValidationException("La fecha de nacimiento no puede ser en el futuro.");
            }
            if (fechaNac.Year < 1900)
            {
                throw new ValidationException("La fecha de nacimiento no puede ser anterior a} 1900.");
            }
        }
        private async Task ValidateNumeroDocumento(string numDoc, int id)
        {
            if (string.IsNullOrWhiteSpace(numDoc))
            {
                throw new ValidationException("El número de documento no puede estar vacío.");
            }
           
            var existingPersona = await _unitOfWork.PersonaRepository.GetByDni(numDoc);
            //en casd e que sea el mismo numero de documento pero la persona no lo actualizó
            if (existingPersona != null && existingPersona.Id != id)
            {
                throw new ValidationException("El número de documento ya está en uso por otra persona.");
            }
           
          
        }

        private  void ValidateSexoId(int sexoId)
        {
            //hombre,mujer,otro
            if (sexoId != 1 && sexoId != 2 && sexoId != 3) {
                throw new ValidationException("El sexo seleccionado noe xiste");

            }
        }
        private void ValidateTelefono(string telefono)
        {

            try
            {
                int esNumero = int.Parse(telefono);

            }
            catch (Exception ex) {
                throw new ValidationException("El telefono es invalido");

            }

        
        }



    }
}
