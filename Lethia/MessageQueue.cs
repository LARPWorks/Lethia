using Lethia.MessageHandlers;
using Lethia.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Lethia
{
    public class MessageQueue
    {
        ConcurrentQueue<MessageRequest> UnhandledEditMessages;
        ConcurrentQueue<MessageRequest> UnhandledReadMessages;

        static List<AngelMessageHandler> ActiveMessageHandlers;

        public MessageQueue() {
            UnhandledEditMessages = new ConcurrentQueue<MessageRequest>();
            UnhandledReadMessages = new ConcurrentQueue<MessageRequest>();
            ActiveMessageHandlers = new List<AngelMessageHandler>
            {
                new AssignToHumanAngel()
            };
        }

        public void AddNewReadMessageRequest(MessageRequest messageRequest) {
            UnhandledReadMessages.Enqueue(messageRequest);
        }

        public void AddNewEditMessageRequest(MessageRequest messageRequest) {
            UnhandledEditMessages.Enqueue(messageRequest);
        }

        public void ProcessUnhandledReadMessages()
        {
            while (!UnhandledReadMessages.IsEmpty)
            {
                if (UnhandledReadMessages.TryDequeue(out MessageRequest message))
                {
                    var RelevantMessageHandlers = ActiveMessageHandlers.Where(messageHandler => (messageHandler.HandledMessageRequestType == MessageRequestType.Read) && messageHandler.GetHandledMessageRequestTypes().Contains(message.MessageRequestDataType));
                    var HighestPriorityMessageHandler = RelevantMessageHandlers.OrderByDescending(messageHandler => messageHandler.PriorityScore).First();

                    HighestPriorityMessageHandler.ProcessMessageRequest(message);
                }
            }
        }

        public void ProcessUnhandledEditMessages()
        {
            while (!UnhandledEditMessages.IsEmpty)
            {
                if (UnhandledEditMessages.TryDequeue(out MessageRequest message))
                {
                    var RelevantMessageHandlers = ActiveMessageHandlers.Where(messageHandler => (messageHandler.HandledMessageRequestType == MessageRequestType.Edit) && messageHandler.GetHandledMessageRequestTypes().Contains(message.MessageRequestDataType));
                    var HighestPriorityMessageHandler = RelevantMessageHandlers.OrderByDescending(messageHandler => messageHandler.PriorityScore).First();

                    HighestPriorityMessageHandler.ProcessMessageRequest(message);
                }
            }
        }
    }
}
