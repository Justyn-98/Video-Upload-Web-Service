using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Responses.Messages
{
    class DatabaseMessage : IMessage
    {
        public enum DatabaseMessageContent
        { 
            DEFAULT_MESSAGE,
            ID_NOT_MATCH,
            RESOURCE_NOT_EXIST,
            RESOURCE_EXIST
        }
        public DatabaseMessageContent Content { get; set; }

        public DatabaseMessage(DatabaseMessageContent content)
        {
            Content = content;
        }

    }
}
