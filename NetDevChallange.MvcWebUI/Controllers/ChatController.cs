using Microsoft.AspNetCore.Mvc;
using NetDevChallange.Business.Abstract;
using NetDevChallange.Entities.Concrete;
using NetDevChallange.MvcWebUI.Models;

namespace NetDevChallange.MvcWebUI.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IChannelService _channelService;
        private readonly IUserService _userService;

        public ChatController(IChatService chatService, IChannelService channelService, IUserService userService)
        {
            _chatService = chatService;
            _channelService = channelService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var model = new GeneralModel
            {
                Channels = await _channelService.GetAllAsync(),
                Chats = await _chatService.GetAllByChannelIdAsync(id),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string message, string username, int channelId)
        {
            var user = await _userService.GetByNameAsync(username);
            Chat chat = new()
            {
                Message = message,
                ChannelId = channelId,
                UserId = user.Id,
                CreatedOn = DateTime.Now,
                CreatedBy = username,
                UpdatedOn = DateTime.Now
            };
            var addedChat = await _chatService.AddAsync(chat);
            return View(addedChat);
        }
    }
}
