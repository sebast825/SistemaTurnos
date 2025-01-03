﻿using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByUser(string name);
        Task<Usuario> GetByPersonaId(int id);
        Task<Usuario> GetByEmail(string email);
        Task<Usuario> GetByToken(string token);

    }
}
