namespace Lethia.Models
{
    public enum MessageRequestType
    {
        None,
        All,
        Character
    }

    public class MessageRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string MessageBody { get; set; }
        public MessageRequestType MessageRequestType { get; set; }
    }
}
