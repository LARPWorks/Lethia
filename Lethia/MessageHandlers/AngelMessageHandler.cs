using Lethia.Models;
using System.Collections.Generic;

namespace Lethia.MessageHandlers
{
    public abstract class AngelMessageHandler
    {
        protected List<MessageRequestDataType> HandledMessageRequestTypes;

        public MessageRequestType HandledMessageRequestType { get; set; }

        public int PriorityScore { get; set; }

        public abstract void ProcessMessageRequest(MessageRequest messageRequest);

        public abstract List<MessageRequestDataType> GetHandledMessageRequestTypes();
    }
}
