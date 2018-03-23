using Lethia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lethia.MessageHandlers
{
    public class AssignToHumanAngel : AngelMessageHandler
    {
        public AssignToHumanAngel()
        {
            HandledMessageRequestTypes = new List<MessageRequestType>();
            // Assign to Human can handle all types
            HandledMessageRequestTypes.AddRange(Enum.GetValues(enumType: typeof(MessageRequestType)).Cast<MessageRequestType>().ToList());
            PriorityScore = 1;
        }

        public override void ProcessMessageRequest(MessageRequest messageRequest)
        {
            if (HandledMessageRequestTypes.Contains(messageRequest.MessageRequestType))
            {
                // Create ticket here
            }
            else
            {
                throw new NotImplementedException($"Messenger of type {GetType()} does not handle messages of type {messageRequest.MessageRequestType}.");
            }
        }

        public override List<MessageRequestType> GetHandledMessageRequestTypes()
        {
            return HandledMessageRequestTypes;
        }
    }
}
