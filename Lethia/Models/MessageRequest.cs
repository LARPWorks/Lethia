namespace Lethia.Models
{
    public enum MessageRequestDataType
    {
        None,
        All,
        Character
    }

    public enum MessageRequestType
    {
        Read,
        Edit
    }

    public class MessageRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string MessageBody { get; set; }
        public MessageRequestType MessageRequestType { get; set; }
        public MessageRequestDataType MessageRequestDataType { get; set; }
    }
}
