using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationException : BaseException
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationException()
            : base("Uno o más errores de validación han ocurrido.", "VALIDATION_ERROR", 400)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(Dictionary<string, string[]> errors)
            : this()
        {
            Errors = errors;
        }

        public ValidationException(string propertyName, string errorMessage)
            : this()
        {
            Errors.Add(propertyName, new[] { errorMessage });
        }
    }
}