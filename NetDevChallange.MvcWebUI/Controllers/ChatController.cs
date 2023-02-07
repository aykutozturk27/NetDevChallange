using Microsoft.AspNetCore.Mvc;
using NetDevChallange.Business.Abstract;
using NetDevChallange.Entities.Concrete;
using NetDevChallange.MvcWebUI.Models;
using Newtonsoft.Json;

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
            var checkUser = await _userService.GetByNameAsync(chat.User.UserName);
            var addedChat = new Chat();
            if (ModelState.IsValid)
            {
                Chat newChat = new()
                {
                    Message = chat.Message,
                    ChannelId = chat.ChannelId,
                    UserId = checkUser.Id,
                    CreatedOn = DateTime.Now,
                    CreatedBy = checkUser.UserName,
                    UpdatedOn = DateTime.Now
                };
                addedChat = await _chatService.AddAsync(newChat);
            }
            return Json(addedChat);
        }
    }
}
