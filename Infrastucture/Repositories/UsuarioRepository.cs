using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(VirticketDbContext context) : base(context)//el :base es el constructor del padre(del generico)
        { }

        public Usuario? GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario? Login(string email, string password)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

 
    }
}