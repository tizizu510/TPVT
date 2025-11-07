using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        string RegistrarUsuario(RegisterDTO dto);
        List<Usuario> ObtenerUsuarios();
        Usuario? ObtenerUsuarioPorId(int id);
        Usuario? ObtenerUsuarioPorEmail(string email);
        void ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int id);
        Usuario? Login(LoginDTO dto);
        void CambiarRolUsuario(int id, string nuevoRol);
        bool ExisteUsuario(int id);
    }
}
