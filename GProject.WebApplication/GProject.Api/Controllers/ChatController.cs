using GProject.Api.MyServices.IServices;
using GProject.Api.MyServices.Services;
using GProject.Data.Context;
using GProject.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace GProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private ChatService chatService;
        private GProjectContext context;
        public ChatController()
        {
            chatService = new ChatService();
            context = new GProjectContext();
        }

        [HttpGet]
        [Route("get-all-mess")]
        public List<GProject.Data.DomainClass.Message> GetAllMessages(string sort)
        {
            try
            {
                if(sort == "asc")
                {
                    return chatService.GetMessages();
                }
                else
                {
                    return chatService.GetMessages().OrderByDescending(x => x.sendDate).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("get-mess-by-id")]
        public List<GProject.Data.DomainClass.Message> GetMessageByUserId(int id ,string userid, string staffid)
        {
            try
            {
                var message = chatService.GetMessages().FirstOrDefault(x => x.Id == id);
                if (message != null)
                {
                    message.staffId = staffid;
                    var isSuucess = context.Messages.Update(message);
                    context.SaveChanges();
                }
                return chatService.GetMessages().Where(x => x.staffId == staffid && x.userId == userid).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
