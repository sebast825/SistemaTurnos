using AutoMapper.Configuration.Conventions;

namespace SistemaTurnos.Service.Interface
{
    public interface IJwtService
    {

        bool UserMatchRequestId(int id);

    }
}
