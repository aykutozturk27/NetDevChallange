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
        public async Task<IActionResult> Index(Chat chat)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetByNameAsync(chat.User.UserName);
                Chat newChat = new()
                {
                    Message = chat.Message,
                    ChannelId = chat.Channel.Id,
                    UserId = user.Id,
                    CreatedOn = DateTime.Now,
                    CreatedBy = user.UserName,
                    UpdatedOn = DateTime.Now
                };
                var addedChat = await _chatService.AddAsync(newChat);
                return View(addedChat);
            }
            else
            {
                return View(chat);
            }
        }
    }
}
