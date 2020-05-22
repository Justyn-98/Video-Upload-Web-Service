using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Responses.Messages
{
    public class Messages : IMessage
    {
        public List<string> Content { get; set; }

        public Messages(List<string> content)
        {
            Content = content;
        }
    }
}
