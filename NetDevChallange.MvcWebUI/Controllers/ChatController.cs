using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NetDevChallange.Business.Abstract;
using NetDevChallange.Entities.Concrete;
using NetDevChallange.MvcWebUI.Models;

namespace NetDevChallange.MvcWebUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IChannelService _channelService;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IChatService chatService, IChannelService channelService, IHubContext<ChatHub> hubContext)
        {
            _chatService = chatService;
            _channelService = channelService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var model = new GeneralModel
            {
                Channels = await _channelService.GetAll(),
                Chats = await _chatService.GetAllByChannelId(id),
            };
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(Chat chat)
        //{
        //    await _hubContext.Clients.All.SendAsync("lastChat", chat);
        //    return View();
        //}
    }
}
