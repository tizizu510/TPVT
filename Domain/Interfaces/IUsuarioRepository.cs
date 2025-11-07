using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        //void Add(Usuario usuario);
        
        // List<Usuario> GetAll();
        Usuario? GetByEmail(string email);

        //  Nuevo método
        Usuario? Login(string email, string password);
    }
}
