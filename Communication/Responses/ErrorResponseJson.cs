using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaPlus.Api.Communication.Responses
{
    public class ErrorResponseJson
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorResponseJson(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}