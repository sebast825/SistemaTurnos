using AutoMapper.Configuration.Conventions;
using SistemaTurnos.Common;

namespace SistemaTurnos.Service.Interface
{
    public interface IJwtService
    {

        bool UserMatchRequestId(int id);

        void isPaciente();
        void isNotPaciente();
  
        void PacienteMatchIdOrAdministrativo(int id);

    }
}
