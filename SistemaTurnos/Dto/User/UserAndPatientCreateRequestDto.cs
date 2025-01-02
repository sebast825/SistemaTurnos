using SistemaTurnos.Dto.Paciente;

namespace SistemaTurnos.Dto.User
{
    public class UserAndPatientCreateRequestDto
    {

        public UserCreateRequestDTO Usuario { get; set; }
        public PacienteCreateRequestDTO Paciente { get; set; }


    }
}
