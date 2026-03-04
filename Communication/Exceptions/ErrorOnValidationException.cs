using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaPlus.Api.Communication.Exceptions
{
    public class ErrorOnValidationException : LivrariaPlusException
    {
        public IList<string> ErrorMessages { get; set; }
        public ErrorOnValidationException(string message)
        {
            ErrorMessages = [message];
        }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}