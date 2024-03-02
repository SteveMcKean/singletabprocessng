using SingleProcessingTab.Spike.Services.Interfaces;

namespace SingleProcessingTab.Spike.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
            
        }
    }
}
