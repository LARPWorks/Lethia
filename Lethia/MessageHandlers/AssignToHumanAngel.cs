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
            HandledMessageRequestTypes = new List<MessageRequestDataType>();
            // Assign to Human can handle all types
            HandledMessageRequestTypes.AddRange(Enum.GetValues(enumType: typeof(MessageRequestDataType)).Cast<MessageRequestDataType>().ToList());
            PriorityScore = 1;
            HandledMessageRequestType = MessageRequestType.Edit;
        }

        public override void ProcessMessageRequest(MessageRequest messageRequest)
        {
            if (HandledMessageRequestTypes.Contains(messageRequest.MessageRequestDataType))
            {
                // Create ticket here
            }
            else
            {
                throw new NotImplementedException($"Messenger of type {GetType()} does not handle messages of type {messageRequest.MessageRequestDataType}.");
            }
        }

        public override List<MessageRequestDataType> GetHandledMessageRequestTypes()
        {
            return HandledMessageRequestTypes;
        }
    }
}
