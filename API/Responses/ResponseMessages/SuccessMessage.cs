using API.Responses.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Responses.ResponseMessages
{
    public class SuccessMessage : IMessage
    {
        public string Success { get; set; }

        public SuccessMessage(string content)
        {
            Success = content;
        }
    }
}
