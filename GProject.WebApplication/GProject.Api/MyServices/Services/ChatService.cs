using GProject.Data.Context;
using GProject.Data.DomainClass;

namespace GProject.WebApplication.Services
{
    public class ChatService
    {
        private GProjectContext gProjectContext = null;
        public ChatService() 
        { 
            gProjectContext = new GProjectContext();
        }
        public List<Message> GetMessages()
        {
            return gProjectContext.Messages.ToList();
        }
    }
}
