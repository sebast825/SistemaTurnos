namespace SistemaTurnos.Service.Interface
{
    public interface IJwtService
    {


        void isPaciente();
        void isNotPaciente();
        void PacienteMatchIdOrOthers(int id);
        void isAdmin();
        void PacienteMatchIdOrAdministrativo(int id);

    }
}
