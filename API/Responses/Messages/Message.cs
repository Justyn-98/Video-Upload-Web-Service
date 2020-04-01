using API.Responses.Messages;

namespace API.Responses
{
    public class Message : IMessage
    {
        public string Content { get; set; }

        public Message(string content)
        {
            Content = content;
        }

        public IMessage GetDeafaultMessage() => new Message(string.Empty);
    }
}
