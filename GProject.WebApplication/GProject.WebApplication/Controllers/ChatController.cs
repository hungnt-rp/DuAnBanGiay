using GProject.Api.MyServices.IServices;
using GProject.Api.MyServices.Services;
using GProject.Data.Context;
using GProject.Data.DomainClass;
using GProject.WebApplication.Helpers;
using GProject.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace GProject.WebApplication.Controllers
{
    public class ChatController : Controller
    {
        public ChatController()
        {
        }
        public async Task<ActionResult> ChatClientIndex()
        {
            var lstObjs = await Commons.GetAll<Message>(String.Concat(Commons.mylocalhost, "Chat/get-all-mess"));
            return View(lstObjs);
        }

        public async Task<ActionResult> ChatAdminIndex()
        {
            var lstObjs = await Commons.GetAll<Message>(String.Concat(Commons.mylocalhost, "Chat/get-all-mess"));
            return View(lstObjs);
        }
    }
}
