using API.Responses.Messages;
using System.Collections.Generic;

namespace API.Responses
{
    public class ErrorMessage : IMessage
    {
        public string Error { get; set; }

        public ErrorMessage(string content)
        {
            Error = content;
        }
    }
}
