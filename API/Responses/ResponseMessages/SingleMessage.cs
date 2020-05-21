using API.Responses.Messages;
using System.Collections.Generic;

namespace API.Responses
{
    public class SingleMessage : IMessage
    {
        public string Content { get; set; }

        public SingleMessage(string content)
        {
            Content = content;
        }
    }
}
