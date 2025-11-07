using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public static class UsuarioExceptions
    {
        public class EmailYaRegistradoException : BaseException
        {
            public EmailYaRegistradoException(string email)
                : base($"El email '{email}' ya está registrado.", "EMAIL_ALREADY_EXISTS", 400)
            {
            }
        }

        public class CredencialesInvalidasException : BaseException
        {
            public CredencialesInvalidasException()
                : base("Credenciales inválidas", "INVALID_CREDENTIALS", 401)
            {
            }
        }

        public class UsuarioNoEncontradoException : BaseException
        {
            public UsuarioNoEncontradoException(int usuarioId)
                : base($"Usuario con id {usuarioId} no fue encontrado.", "USER_NOT_FOUND", 404)
            {
            }

            public UsuarioNoEncontradoException(string email)
                : base($"Usuario con email '{email}' no fue encontrado.", "USER_NOT_FOUND", 404)
            {
            }
        }
    }
}