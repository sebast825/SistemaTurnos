﻿using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context)
        {

        }
      
        public async Task<Usuario> GetByUser(string name)
        {
            Console.WriteLine("get by user");
            
            var usuario = await _context.Usuarios
                .Include(x => x.Persona)
                .Where(x => x.UserName == name)
                .FirstOrDefaultAsync();
            return usuario;
        }
    }
}