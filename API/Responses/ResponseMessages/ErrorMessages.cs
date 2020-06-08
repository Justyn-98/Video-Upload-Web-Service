using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Responses.Messages
{
    public class ErrorMessages : IMessage
    {
        public List<string> Errors { get; set; }

        public ErrorMessages(List<string> errors)
        {
            Errors = errors;
        }
    }
}
