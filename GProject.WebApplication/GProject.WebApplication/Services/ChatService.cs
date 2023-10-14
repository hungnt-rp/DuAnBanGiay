using GProject.Data.Context;
using GProject.Data.DomainClass;
using GProject.WebApplication.Helpers;

namespace GProject.WebApplication.Services
{
    public class ChatService
    {
        private GProjectContext gProjectContext;
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
