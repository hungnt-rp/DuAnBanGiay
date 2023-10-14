using GProject.Data.Context;
using GProject.Data.DomainClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Logistics.WebAppAdmin.HubConfig
{
    public class RealTimeHub : Hub
    {
        private GProjectContext _context;
        public RealTimeHub(GProjectContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string body)
        {
            try
            {
                ItemMessage model = JsonConvert.DeserializeObject<ItemMessage>(body);
                Message chat = new Message();
                chat.userId = model?.userId.ToLower();
                chat.staffId = model.staffId;
                chat.sendDate = DateTime.Now;
                chat.content = model?.content;
                chat.isAdmin = model?.isAdmin;
                _context.Messages.Add(chat);
                _context.SaveChanges();
                // Xử lý tin nhắn ở đây
                await Clients.All.SendAsync("ReceiveMessage", model.userId, model.staffId, model.content, chat.sendDate, model.isAdmin);
            }
            catch (Exception ex)
            {
                // Gửi thông báo lỗi về máy khách
                await Clients.Caller.SendAsync("ErrorMessage", ex.Message);
            }
        }
    }

    public class ItemMessage 
    {
        public string? userId { get; set; }
        public string? staffId { get; set; }
        public string? content { get; set; }
        public Boolean? isAdmin { get; set; }
    }
}
